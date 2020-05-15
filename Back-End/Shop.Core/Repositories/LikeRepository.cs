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
    public class LikeRepository : ILikeRepository
    {
        private readonly ShopContext _context;
      
  
        public LikeRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<Like>> GetLikesByReviewAsync( Guid reviewId)
        {
            List<Like> useritemdto = await _context.Likes.Where(e=> e.ReviewId == reviewId).ToListAsync();
            return useritemdto;
        }

     

        public async Task<Like> CreateAsync(Like like)
        {
            var result = await _context.Likes.AddAsync(like);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> UpdateAsync(Like like)
        {
            var UserItem = await _context.Likes.FirstOrDefaultAsync(x => x.UserId == like.UserId && x.ReviewId ==like.ReviewId);
            if (UserItem == null)
            {
                var result = await _context.Likes.AddAsync(like);
                await _context.SaveChangesAsync();
                return true;
            }
            UserItem.Type = like.Type;
            _context.Likes.Update(UserItem);
            await _context.SaveChangesAsync();
            return true;
        }

      



        }
    }
