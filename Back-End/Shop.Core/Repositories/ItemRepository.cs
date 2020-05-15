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
    public class ItemRepository: IItemRepository
    {
        private readonly ShopContext _context;
        


        public ItemRepository(ShopContext context )
        {
            _context = context;

        }
        private async Task<ItemDto> Convert(ItemDto ut)
        {
            var list = _context.Ratings.Where(x => x.ItemId ==ut.Id).ToList();
            ut.Stars = 0;
            foreach (Rating rat in list)
            {
                ut.Stars = ut.Stars + rat.Star;
            }
            ut.KStars = list.Count;
            return ut;
        }
        public async Task<List<ItemDto>> GetAllAsync()
        {
            var items  = ItemConverter.Convert(await _context.Items.ToListAsync());
            foreach(ItemDto it in items)
            {
                await Convert(it);
            }
            return items;
        }

        public async Task<ItemDto> GetByIdAsync(Guid id)
        {
            ItemDto item = await Convert(ItemConverter.Convert(await _context.Items.FindAsync(id)));
            return item;
        }

        public async Task<ItemDto> CreateAsync(ItemDto item)
        {
            var result = await _context.Items.AddAsync(ItemConverter.Convert(item));
            await _context.SaveChangesAsync();
            return await Convert(ItemConverter.Convert(result.Entity));
        }

        public async Task<bool> UpdateAsync(ItemDto item)
        {
            var Item = await _context.Items.FirstOrDefaultAsync(x => x.Id == item.Id);
            if ( Item== null)
                return false;
            Item.Name = item.Name;
            Item.Img = item.Img;
            Item.CategoryId = item.CategoryId;
            Item.Cost = item.Cost;
            Item.Views = item.Views;
            Item.Grams = item.Grams;
            Item.Text = item.Text;
            Item.Status = item.Status;
            Item.Komplex = item.Komplex;
            //Item.LongText = item.LongText;

            _context.Items.Update(Item);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var item = await  _context.Items.FindAsync(id);
            if (item == null)
                return false;
            List<Rating> ratings = _context.Ratings.Where(e => e.ItemId == item.Id).ToList();
            foreach(Rating rating in ratings)
            {
                _context.Ratings.Remove(rating);
            }
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<List<ItemDto>> GetByCategoryAsync(Guid id)
        {
            var items = ItemConverter.Convert(await _context.Items.Where(x => x.CategoryId == id).ToListAsync());
            foreach (ItemDto it in items)
            {
                await Convert(it);
            }
            return items;
        }

    }
}
