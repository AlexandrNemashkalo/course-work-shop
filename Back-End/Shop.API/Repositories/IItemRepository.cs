using Shop.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IItemRepository
    {
        Task<List<ItemDto>> GetAllAsync();
        Task<ItemDto> GetByIdAsync(Guid Id);
        Task<ItemDto> CreateAsync(ItemDto item);
        Task<bool> UpdateAsync(ItemDto item);
        Task<bool> DeleteAsync(Guid id);
        Task<List<ItemDto>> GetByCategoryAsync(Guid id);
      
    }
}
