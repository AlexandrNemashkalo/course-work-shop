using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Interfaces
{
    public interface IChat
    {
        Task<List<ReviewDto>> Get();
        Task<List<ReviewDto>> GetByItem(Guid id);
        Task<List<ReviewDto>> GetByUser(Guid id);
        Task<bool> Delete(Guid id);
        Task<bool> Edit([FromBody] Review item);
        Task<ActionResult<bool>> SendAuth([FromBody] ReviewDto review);
    }
}
