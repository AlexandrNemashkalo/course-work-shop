using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Interfaces
{
    public interface ILike
    {
        Task<IActionResult> Get(Guid id);
        Task<IActionResult> Post([FromBody] Like item);
        Task<IActionResult> Put([FromBody] Like item);
    }
}
