using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<List<OrderDto>> GetAllAsync();
        Task<OrderDto> GetByIdAsync(int Id);
        Task<OrderDto> CreateAsync(Order item);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(Order order);

        //Task<List<ItemDto>> GetItemsByUserAsync(Guid userId);
        //Task<List<ItemDto>> GetUserItemsByOrderAsync(Guid userId);
        Task<List<OrderDto>> GetOrderByUserAsync(Guid userId);
        //Task<List<UserDto>> GetUsersByItemAsync(Guid userId);

        //Task<List<UserItemDto>> GetAllByUserAsync(Guid userId);
        

        //Task<List<ItemDto>> GetRecommendationsAsync(Recom recom);
    }
}
