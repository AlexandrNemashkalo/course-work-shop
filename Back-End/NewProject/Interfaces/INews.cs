using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Interfaces
{
    public interface INews
    {
        Task<IActionResult> Get();
        Task<IActionResult> Delete(Guid id);
        Task<IActionResult> Update([FromBody] News ev);
        Task<IActionResult> Post([FromBody] News ev);
    }
}
