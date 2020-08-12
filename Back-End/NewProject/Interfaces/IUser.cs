using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Interfaces
{
    public interface IUser
    {
        Task<ActionResult<List<UserDto>>> Get();
        Task<ActionResult<UserDto>> Get(Guid id);
        Task<ActionResult<UserDto>> GetByEmail(string email);
        Task<ActionResult<UserDto>> Post([FromBody] UserDto item);
        Task<ActionResult<bool>> Put([FromBody] UserDto item);
        Task<ActionResult<bool>> Delete(Guid id);

    }
}
