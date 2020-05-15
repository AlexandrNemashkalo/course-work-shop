using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Core.EF;
using Shop.Domain.Converters;
using Shop.Domain.Dto;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly UserManager<User> _um;
  

        private readonly ShopContext _context;
        /*private readonly IItemRepository _item;
        private readonly IUserRepository _user;*/


        public UserRepository(UserManager<User> um , ShopContext context)
        {
            _context = context;
            _um = um;
        }
        async public Task<List<UserDto>> GetAll()
        {
            var usersDto = UserConverter.Convert(await _um.Users.ToListAsync());
            var users = await _um.Users.ToListAsync();
            foreach (UserDto user in usersDto) {
                user.IsAdmin = await _um.IsInRoleAsync(UserConverter.Convert(user), "admin");
            }
            return usersDto;
        }

        async public Task<UserDto> GetById(Guid id)
        {
            var user = UserConverter.Convert(await _um.FindByIdAsync(id.ToString()));
            user.IsAdmin = await _um.IsInRoleAsync(UserConverter.Convert(user), "admin");
            return user;
        }

        async public Task<UserDto> GetByEmail(string email)
        {
            var user = UserConverter.Convert(await _um.FindByEmailAsync(email));
            user.IsAdmin = await _um.IsInRoleAsync(UserConverter.Convert(user), "admin");
            return user;
        }

        async public Task<UserDto> Create(UserDto user)
        {
            var result = await _um.CreateAsync(UserConverter.Convert(user));
            if (result.Succeeded)
            {
                return UserConverter.Convert(await _um.FindByEmailAsync(user.Email));
            }
            return null;
        }
        public async Task<bool> Update(UserDto user)
        {
            return (await _um.UpdateAsync(UserConverter.Convert(user))).Succeeded;
        }

        public async Task<bool> Delete(Guid id)
        {
            List<Like> likes = await  _context.Likes.Where(e => e.UserId == id).ToListAsync();
            foreach(Like like in likes)
            {
                _context.Likes.Remove(like);
                _context.SaveChanges();
            }
            return (await _um.DeleteAsync(await _um.FindByIdAsync(id.ToString()))).Succeeded;
        }


    }

}
