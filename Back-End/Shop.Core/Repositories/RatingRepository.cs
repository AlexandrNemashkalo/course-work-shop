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
    public class RatingRepository: IRatingRepository
    {
        private readonly ShopContext _context;
        private readonly IItemRepository _item;



        public RatingRepository(ShopContext context, IItemRepository item )
        {
            _item = item;
            _context = context;
        }
        public async Task<List<RatingDto>> GetAllRatingsAsync()
        {
            List<RatingDto> ratings = RatingConverter.Convert(_context.Ratings.Where(x => true).ToList());
            foreach (RatingDto rating in ratings)
            {
                rating.ItemName = _context.Items.FirstOrDefaultAsync(x => x.Id == rating.ItemId).Result.Name;
            }
            return ratings;
        }


        public async Task<List<RatingDto>> GetRatingsByItemAsync(Guid id)
        {
            List<RatingDto> ratings = RatingConverter.Convert(_context.Ratings.Where(x => x.ItemId == id).ToList());
            foreach (RatingDto rating in ratings)
            {
                rating.ItemName = _context.Items.FirstOrDefaultAsync(x => x.Id == rating.ItemId).Result.Name;
            }
            return ratings;
        }

        public async  Task<List<RatingDto>> GetRatingsByUserAsync(Guid id)
        {
            List<RatingDto> ratings = RatingConverter.Convert(_context.Ratings.Where(x => x.UserId == id).ToList());
            foreach (RatingDto rating in ratings)
            {
               rating.ItemName =   _context.Items.FirstOrDefaultAsync(x => x.Id == rating.ItemId).Result.Name;
            }
            return ratings;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var album = await _context.Ratings.FirstOrDefaultAsync(x => x.Id == id);
            if (album == null)
                return false;
            _context.Ratings.Remove(album);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<RatingDto> CreateAsync(Rating rating)
        {
            //var RATING
            var R = await _context.Ratings.FirstOrDefaultAsync(x => x.UserId == rating.UserId && x.ItemId == rating.ItemId);
            if (R == null)
            {
               
                var result = await _context.Ratings.AddAsync(rating);
                await _context.SaveChangesAsync();

                return RatingConverter.Convert(result.Entity);
            }
            else
            {

                R.Star = rating.Star;
                return await this.UpdateAsync(R);
            }
        }

        public async Task<RatingDto> UpdateAsync(Rating rating)
        {
            var RATING = await _context.Ratings.FirstOrDefaultAsync(x => x.Id == rating.Id);
            RATING.Star = rating.Star;
   
            _context.Ratings.Update(RATING);
            await _context.SaveChangesAsync();
            return RatingConverter.Convert(RATING);
            
            

        }

        

    }
}
