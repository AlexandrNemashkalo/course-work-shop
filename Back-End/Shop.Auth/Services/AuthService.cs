using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Shop.Auth.Interfaces;
using Shop.Core.EF;
using Shop.Domain.Converters;
using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Auth.Services
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

        public async Task<object> Login(string email, string password)
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
        }

        public async Task<object> Register(UserDto item)
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
        }

    }
}
