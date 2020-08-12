using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Interfaces
{
    public interface IRole
    {
        Task<ActionResult<List<IdentityRole<Guid>>>> Get();
        Task<ActionResult<IdentityRole<Guid>>> Get(Guid id);
        Task<ActionResult<IdentityRole<Guid>>> GetByEmai(string email);
        Task<ActionResult<IdentityRole<Guid>>> Post([FromBody] IdentityRole<Guid> item);
        Task<ActionResult<bool>> Put([FromBody] IdentityRole<Guid> item);
        Task<ActionResult<bool>> Delete(Guid id);
    }
}
