using Microsoft.EntityFrameworkCore;
using Shop.Core.EF;
using Shop.Domain.Converters;
using Shop.Domain.Dto;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<CategoryDto> CreateAsync(CategoryDto category)
        {
            if (category.Img == null || category.Img == "")
                category.Img = "/images/icon.png";
            else
            { 
                Guid id = Guid.NewGuid();
                string base64str = category.Img.Substring(category.Img.IndexOf(',') + 1);
                byte[] bytes = System.Convert.FromBase64String(base64str);
                File.WriteAllBytes("wwwroot/images/category/" + id + ".png", bytes);
                category.Img = "/images/category/" + id + ".png";
            };
            var result = await _context.Categories.AddAsync(CategoryConverter.Convert(category));
            await _context.SaveChangesAsync();
            return CategoryConverter.Convert(result.Entity);
        }

        public async Task<bool> UpdateAsync(CategoryDto category)
        {
            Category Category = await _context.Categories.FirstOrDefaultAsync(x => x.Id== category.Id);
            if (Category == null)
                return false;

            if (category.Img != "/images/icon.png" && category.Img != "" && category.Img != null)
            {
                Guid id = Guid.NewGuid();
                string base64str = category.Img.Substring(category.Img.IndexOf(',') + 1);
                byte[] bytes = System.Convert.FromBase64String(base64str);
                File.WriteAllBytes("wwwroot/images/category/" + id + ".png", bytes);

                FileInfo fileInf = new FileInfo("wwwroot" + Category.Img);
                if (fileInf.Exists)
                    fileInf.Delete();
                Category.Img = "/images/category/" + id + ".png";
            };

            Category.Name = category.Name;
             _context.Categories.Update(Category);
            // _context.Categories.Update(CategoryConverter.Convert(item));
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var category= await _context.Categories.FindAsync(id);
            if (category == null)
                return false;
            if (category.Img != "/images/icon.png")
            {
                FileInfo fileInf = new FileInfo("wwwroot" + category.Img);
                if (fileInf.Exists)
                {
                    fileInf.Delete();
                    // альтернатива с помощью класса File
                    // File.Delete(path);
                };
            };
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}