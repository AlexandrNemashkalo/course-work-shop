using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Repositories
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllAsync();
        Task<bool> UpdateAsync(Event e);
        Task<bool> DeleteAsync(Guid id);
        Task<Event> CreateAsync(Event e);
        }
}
