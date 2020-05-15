using Microsoft.EntityFrameworkCore;
using Shop.Core.EF;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly ShopContext _context;

        public NewsRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<News>> GetAllAsync()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<bool> UpdateAsync(News E)
        {
            News ev = await _context.News.FirstOrDefaultAsync(e => e.Id == E.Id);
            if (ev == null)
            {
                return false;
            }
            ev.Text = E.Text;
            ev.Date = E.Date;
            ev.Link = E.Link;
            ev.Img = E.Img;
            _context.News.Update(ev);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            News ev = await _context.News.FirstOrDefaultAsync(e => e.Id == id);
            if (ev == null)
            {
                return false;
            }
            _context.News.Remove(ev);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<News> CreateAsync(News E)
        {
            
            var result = await _context.News.AddAsync(E);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
