using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Interfaces
{
    public interface IOrder
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get(int id);
        Task<IActionResult> Get(Guid id);
        Task<IActionResult> Post([FromBody] Order item);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Update([FromBody] Order useritem);
    }
}
