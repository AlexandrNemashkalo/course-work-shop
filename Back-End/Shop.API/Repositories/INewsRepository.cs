using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface INewsRepository
    {
        Task<List<News>> GetAllAsync();
        Task<bool> UpdateAsync(News e);
        Task<bool> DeleteAsync(Guid id);
        Task<News> CreateAsync(News e);
    }
}
