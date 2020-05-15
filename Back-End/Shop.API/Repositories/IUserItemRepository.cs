using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IUserItemRepository
    {
        Task<List<UserItemDto>> GetAllAsync();
        Task<UserItemDto> GetByIdAsync(Guid Id);
        Task<UserItemDto> CreateAsync(UserItem item);
        Task<bool> DeleteAsync(Guid id);
        Task<List<ItemDto>> GetItemsByUserAsync(Guid userId);
        Task<List<UserItemDto>> GetUserItemsByUserAsync(Guid userId);
        Task<List<UserDto>> GetUsersByItemAsync(Guid userId);
        Task<List<UserItemDto>> GetAllByUserAsync(Guid userId);
        Task<bool> UpdateAsync(UserItem useritem);
        Task<List<ItemDto>> GetRecommendationsAsync(Recom recom);
        Task<List<UserItemDto>> GetUserItemsByOrderAsync(int orderId);




    }
}
