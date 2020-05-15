using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<List<IdentityRole<Guid>>> GetAll();
        Task<IdentityRole<Guid>> GetById(Guid id);
        Task<IdentityRole<Guid>> GetByName(string name);
        Task<IdentityRole<Guid>> Create(IdentityRole<Guid> item);
        Task<bool> Update(IdentityRole<Guid> item);
        Task<bool> Delete(Guid id);
    }
}
