using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Interfaces
{
    public interface ICategory
    {
        Task<IActionResult> Get();
        Task<IActionResult> GetAsync(Guid id);

        Task<IActionResult> Post([FromBody] CategoryDto item);
        Task<IActionResult> Put([FromBody] CategoryDto item);
        Task<IActionResult> Delete(Guid id);
    
    }
}
