using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Shop.Core.Interfaces;
using Shop.Core.EF;
using Shop.Domain.Converters;
using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Shop.Core.Models;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;

namespace Shop.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IJwtGenerator _jwt;
        private readonly ShopContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(SignInManager<User> sim, UserManager<User> um, IJwtGenerator jwt, ShopContext context,
            IConfiguration configuration)
        {
            _signInManager = sim;
            _userManager = um;
            _jwt = jwt;
            _context = context;
            _configuration = configuration;
        }

        public async Task<Response<Token>> Login(string email, string password)
        {
            try
            {
                if (email == null || password == null)
                    return new Response<Token>(400, "Invalid email or password");

                var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

                if (result.Succeeded)
                {
                    var appUser = await _userManager.FindByEmailAsync(email);
                    return await _jwt.GenerateJwt(appUser);
                }
                return new Response<Token>(400, "Invalid email or password");
            }
            catch (Exception)
            {
                return new Response<Token>(520, "Unknown error");
            }
        }

        public async Task<Response<Token>> RefreshToken(string token, string refreshToken)
        {
            try
            {
                var principal = GetPrincipalFromExpiredToken(token);
                if (principal == null)
                    return new Response<Token>(400, "Invalid access token");
                var email = principal.Identity.Name;
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                    return new Response<Token>(404, "User not found");
                var dbToken = _context.RefreshTokens
                    .FirstOrDefault(rt => rt.UserId == user.Id && rt.Token == refreshToken);
                if (dbToken == null)
                    return new Response<Token>(400, "Invalid refresh token");
                if (dbToken.ExpiresDate < DateTime.Now)
                {
                    _context.RefreshTokens.Remove(dbToken);
                    await _context.SaveChangesAsync();
                    return new Response<Token>(400, "Expired refresh token");
                }
                var data = await _jwt.GenerateJwt(user);
                if (data.Succeeded())
                {
                    _context.RefreshTokens.Remove(dbToken);
                    await _context.SaveChangesAsync();
                }
                return data;
            }
            catch (Exception )
            {
                return new Response<Token>(520, "Unknown error");
            }
        }

        public async Task<Response<Token>> Register(UserDto item)
        {
            try
            {
                User user = UserConverter.Convert(item);
                if (user == null)
                    return new Response<Token>(400, "Invalid email or password");

                var result = await _userManager.CreateAsync(user, item.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "admin");
                    await _signInManager.SignInAsync(user, false);
                    var res = await _jwt.GenerateJwt(user);

                    // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                   /* var callbackUrl = Url.Action(
                          "ConfirmEmail",
                          "Account",
                          new { userId = user.Id, code = code },
                          protocol: HttpContext.Request.Scheme);*/

                    EmailService emailService = new EmailService();
                    try
                    {
                        await emailService.SendEmailAsync(item.Email, "Confirm your account",
                        $"Подтвердите регистрацию, перейдя по ссылке: <a href='{res}'>сюда</a>");
                    }
                    catch(Exception e)
                    {
                        return new Response<Token>(400, e.ToString());
                    }
                    //return res;
                    return new Response<Token>(200, "Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                }

                return new Response<Token>(400, "Invalid data");
            }
            catch (Exception)
            {
                return new Response<Token>(520, "Unknown error!");
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = _configuration["Audience"],
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Issuer"],
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"])),
                    ValidateLifetime = false
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
                var jwtSecurityToken = securityToken as JwtSecurityToken;
                if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                                                            StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException();

                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }


        


        /* public async Task<object> Login(string email, string password)
         {
             try
             {
                 if (email == null || password == null)
                     return null;
                 var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
                 if (result.Succeeded)
                 {
                     var appUser = await _userManager.FindByEmailAsync(email);
                     return await _jwt.GenerateJwt(appUser);
                 }
                 return null;
             }
             catch (Exception)
             {
                 return null;
             }
         }*/

        /* public async Task<object> Register(UserDto item)
         {
             try
             {
                 User user = UserConverter.Convert(item);
                 if (user == null)
                     return null;
                 var result = await _userManager.CreateAsync(user, item.Password);
                 if (result.Succeeded)
                 {
                     await _userManager.AddToRoleAsync(user, "user");
                     await _signInManager.SignInAsync(user, false);
                     return await _jwt.GenerateJwt(user);
                 }
                 return null;
             }
             catch (Exception)
             {
                 return null;
             }
         }*/
    }
}
