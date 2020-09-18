using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Shop.API.Interfaces;
using Shop.API.Models;
using Shop.API.ViewModels;
using Shop.Core.Interfaces;
using Shop.Core.Models;
using Shop.Core.Services;
using Shop.Domain.Converters;
using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("api/[action]")]
    public class AuthController : Controller, IAuth
    {
        private readonly IAuthService _auth;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtGenerator _jwt;
        private readonly IConfiguration _configuration;


        public AuthController(IAuthService auth, UserManager<User> userManager, IJwtGenerator jwt, SignInManager<User> signInManager, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _auth = auth;
            _jwt = jwt;
            _configuration = configuration;
        }

        [HttpPost]
        [Produces(typeof(Response<Token>))]
        public async Task<ActionResult<Response<Token>>> Login([FromBody] LoginViewModel form)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(form.Email);
                if (!await _userManager.IsEmailConfirmedAsync(user))
                {
                    var result = await _auth.Login(form.Email, form.Password);
                    return StatusCode(200, new Ack<Token>(result));
                }
                else
                {
                    var result2 = await _auth.Login(form.Email, form.Password);
                    return StatusCode(result2.Code, new Ack<Token>(result2));
                }

            }
            catch (Exception)
            {
                return StatusCode(520, new Ack<Token>(null, "Unknown error"));
            }
        }

        [HttpPost]
        [Produces(typeof(Response<Token>))]
        public async Task<ActionResult<Response<Token>>> Register([FromBody] UserDto item)
        {
            try
            {
                try
                {
                    User user1 = UserConverter.Convert(item);
                    if (user1 == null)
                        return StatusCode(400, "Invalid email or password");

                    User user = new User { Email = item.Email, UserName = item.Email, Name =item.Name };
                    var result = await _userManager.CreateAsync(user, item.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "user");
                        await _signInManager.SignInAsync(user, false);
                        var res = await _jwt.GenerateJwt(user);
                        try
                        {
                            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                            var callbackUrl = Url.Action(
                                  "ConfirmEmail",
                                  "Auth",
                                  new { userId = user.Id, code = code },
                                  protocol: HttpContext.Request.Scheme);

                            EmailService emailService = new EmailService(_configuration);
                            await emailService.SendEmailAsync(item.Email, "Confirm your account",
                            $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>сюда</a>");
                        }
                        catch(Exception e)
                        {
                            return StatusCode(400, e.ToString());
                        }
                        //return res;
                        return StatusCode(res.Code, new Ack<Token>(res));
                    }
                    return StatusCode(400, "Invalid data");   
                }
                catch (Exception)
                {
                    return StatusCode(520, "Unknown error!");
                }
            }
            catch (Exception)
            {
                return StatusCode(520, new Ack<Token>(null, "Unknown error"));
            }
        }

        [HttpPost("{id}")]
        [AllowAnonymous]
        public async Task<bool> Send(Guid id)
        { 
           try{
              User user =await  _userManager.FindByIdAsync(id.ToString());
              var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
              var callbackUrl = Url.Action(
              "ConfirmEmail",
              "Auth",
              new { userId = user.Id, code = code },
              protocol: HttpContext.Request.Scheme);

              EmailService emailService = new EmailService(_configuration);
              await emailService.SendEmailAsync(user.Email, "Confirm your account",
                            $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>сюда</a>");
                return true;
              }
          catch(Exception e){
              return false;
           }

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View(false);
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View(false);
            }
            var result = await _userManager.ConfirmEmailAsync(user, code);

            return View(true);


        }

        [HttpPost]
        [Produces(typeof(Response<Token>))]
        public async Task<ActionResult<Response<Token>>> RefreshToken([FromBody] RefreshViewToken item)
        {
            try
            {
                var result = await _auth.RefreshToken(item.AccessToken, item.RefreshToken);
                return StatusCode(result.Code, new Ack<Token>(result));
            }
            catch (Exception)
            {
                return StatusCode(520, new Ack<Token>(null, "Unknown error"));
            }
        }

        [HttpGet]
        [Authorize]
        [Produces(typeof(bool))]
        public ActionResult<bool> Test()
        {
            return true;
        }





        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // пользователь с данным email может отсутствовать в бд
                    // тем не менее мы выводим стандартное сообщение, чтобы скрыть 
                    // наличие или отсутствие пользователя в бд
                    return StatusCode(400 ,null);
                }

                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var callbackUrl = Url.Action("ResetPassword", "Auth", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                EmailService emailService = new EmailService(_configuration);
                await emailService.SendEmailAsync(model.Email, "Reset Password",
                    $"Для сброса пароля пройдите по ссылке: <a href='{callbackUrl}'>link</a>");
                return StatusCode(200, true);
            }
            //return View(model);
            return Ok();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string code = null)
        {
            return code == null ? View("Error") : View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return View("Error");
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return View("ResetPasswordConfirmation");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }




    }
}
