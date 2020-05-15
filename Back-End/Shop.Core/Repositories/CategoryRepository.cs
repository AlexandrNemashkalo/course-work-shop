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
    public class CategoryRepository: ICategoryRepository
    {
        private readonly ShopContext _context;


        public CategoryRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return CategoryConverter.Convert(await _context.Categories.ToListAsync());
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            CategoryDto item = CategoryConverter.Convert(await _context.Categories.FindAsync(id));

            return item;
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto item)
        {
            var result = await _context.Categories.AddAsync(CategoryConverter.Convert(item));
            await _context.SaveChangesAsync();
            return CategoryConverter.Convert(result.Entity);
        }

        public async Task<bool> UpdateAsync(CategoryDto item)
        {
            Category Item = await _context.Categories.FirstOrDefaultAsync(x => x.Id==item.Id);
            if (Item == null)
                return false;
            Item.Name = item.Name;
             _context.Categories.Update(Item);
            // _context.Categories.Update(CategoryConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var item = await _context.Categories.FindAsync(id);
            if (item == null)
                return false;
            _context.Categories.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}