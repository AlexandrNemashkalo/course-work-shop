using Microsoft.AspNetCore.Mvc;
using Shop.API.ViewModels;
using Shop.Core.Models;
using Shop.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Interfaces
{
    public interface IAuth
    {
        Task<ActionResult<Response<Token>>> Login([FromBody] LoginViewModel form);
        Task<ActionResult<Response<Token>>> Register([FromBody] UserDto item);
        Task<bool> Send(Guid id);
        Task<IActionResult> ConfirmEmail(string userId, string code);
        Task<ActionResult<Response<Token>>> RefreshToken([FromBody] RefreshViewToken item);
        ActionResult<bool> Test();
        Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordViewModel model);
        IActionResult ResetPassword(string code = null);
        Task<IActionResult> ResetPassword(ResetPasswordViewModel model);
    }
}
