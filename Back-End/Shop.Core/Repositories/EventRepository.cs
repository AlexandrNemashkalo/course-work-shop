using Microsoft.EntityFrameworkCore;
using Shop.Core.EF;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public class EventRepository: IEventRepository
    {
        private readonly ShopContext _context;

        public EventRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<Event>> GetAllAsync()
        {
            return await _context.Events.ToListAsync();
        }

        public async  Task<bool> UpdateAsync(Event E)
        {
            Event ev =  await _context.Events.FirstOrDefaultAsync(e => e.Id == E.Id);
            if (ev == null)
            {
                return false;
            }
            ev.Text = E.Text;
            ev.Date = E.Date;
            _context.Events.Update(ev);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Event ev = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (ev == null)
            {
                return false;
            }
            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Event> CreateAsync(Event E)
        {
            var result = await _context.Events.AddAsync(E);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

    }
}
