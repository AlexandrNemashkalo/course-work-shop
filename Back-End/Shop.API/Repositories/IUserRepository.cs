using Shop.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<UserDto>> GetAll();
        Task<UserDto> GetById(Guid id);
        Task<UserDto> GetByEmail(string email);
        Task<UserDto> Create(UserDto user);
        Task<bool> Update(UserDto user);
        Task<bool> Delete(Guid id);
    }
}
