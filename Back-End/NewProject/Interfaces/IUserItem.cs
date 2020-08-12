using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Interfaces
{
    public interface IUserItem
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get(Guid id);
        Task<IActionResult> Get(int id);
        Task<IActionResult> Post([FromBody] UserItem item);
        Task<IActionResult> Delete(Guid id);
        Task<IActionResult> GetUsers(Guid id);
        Task<IActionResult> GetItems(Guid id);
        Task<IActionResult> Update([FromBody] UserItem useritem);
        Task<IActionResult> GetAllByUser(Guid id);
        Task<IActionResult> GetRecommendations([FromBody] Recom recom);
        Task<IActionResult> GetUserItemsByUser(Guid id);
    }
}
