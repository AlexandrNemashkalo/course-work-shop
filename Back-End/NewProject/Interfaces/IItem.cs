using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Interfaces
{
    public interface IItem
    {
        Task<IActionResult> Get();
        Task<IActionResult> GetAsync(Guid id);

        Task<IActionResult> Post([FromBody] ItemDto item);
        Task<IActionResult> Put([FromBody] ItemDto item);
        Task<IActionResult> Delete(Guid id);
        Task<IActionResult> GetByCategory(Guid id);
       
    }
}
