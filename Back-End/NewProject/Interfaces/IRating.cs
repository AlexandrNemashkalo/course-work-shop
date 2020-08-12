using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Interfaces
{
    public interface  IRating
    {
        Task<IActionResult> Get();
        Task<IActionResult> Delete(Guid id);
        Task<IActionResult> GetRatingsByUser(Guid id);
        Task<IActionResult> GetRatingsByItem(Guid id);
        Task<IActionResult> Post([FromBody] Rating item);
        Task<IActionResult> Put([FromBody] Rating item);
    }
}
