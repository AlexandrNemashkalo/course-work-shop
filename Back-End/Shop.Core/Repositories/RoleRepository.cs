using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public class RoleRepository: IRoleRepository
    {
        private readonly RoleManager<IdentityRole<Guid>> _um;
        public RoleRepository(RoleManager<IdentityRole<Guid>> um)
        {
            _um = um;
        }
        async public Task<List<IdentityRole<Guid>>> GetAll()
        {
            return await _um.Roles.ToListAsync();
        }

        async public Task<IdentityRole<Guid>> GetById(Guid id)
        {
            return await _um.FindByIdAsync(id.ToString());
        }

        async public Task<IdentityRole<Guid>> GetByName(string name)
        {
            return await _um.FindByNameAsync(name);
        }

        async public Task<IdentityRole<Guid>> Create(IdentityRole<Guid> item)
        {
            var result = await _um.CreateAsync(item);
            if (result.Succeeded)
            {
                return await _um.FindByIdAsync(item.Id.ToString());
            }
            return null;
        }
        public async Task<bool> Update(IdentityRole<Guid> item)
        {
            return (await _um.UpdateAsync(item)).Succeeded;
        }
        public async Task<bool> Delete(Guid id)
        {
            return (await _um.DeleteAsync(await _um.FindByIdAsync(id.ToString()))).Succeeded;
        }
    }
}
