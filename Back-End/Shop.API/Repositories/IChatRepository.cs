using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IChatRepository
    {
        Task<List<ReviewDto>> GetAllAsync();
        Task<ReviewDto> CreateAsync(ReviewDto item);
        Task<bool> EditAsync(ReviewDto item);
        Task<bool> DeleteAsync(Guid id);
        Task<List<ReviewDto>> GetByItemAsync(Guid id);
    }
}
