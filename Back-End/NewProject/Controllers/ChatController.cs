using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Shop.Core.EF;
using Shop.Core.Hubs;
using Shop.Core.Repositories;
using Shop.Domain.Converters;
using Shop.Domain.Dto;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller 
    {
        private readonly IHubContext<AuthChatHub> _authHubContext;
        private readonly ShopContext _context;
        private readonly IUserRepository _userRepository;
        private readonly IItemRepository _itemRepository;

        public ChatController(IHubContext<AuthChatHub> ahc ,ShopContext context, IUserRepository userRepository, IItemRepository itemRepository)
        {
            _authHubContext = ahc;
            _context = context;
            _userRepository = userRepository;
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public async Task<List<ReviewDto>> Get()
        {
            var result = ReviewConverter.Convert(await _context.Review.ToListAsync());
            for (int i = 0; i < result.Count; i++)
            {
                result[i].KLikes = _context.Likes.Where(e => e.ReviewId == result[i].Id && e.Type ==true).Count();
                result[i].KDisLikes = _context.Likes.Where(e => e.ReviewId == result[i].Id && e.Type == false).Count();
                result[i].ItemName = _itemRepository.GetByIdAsync(result[i].ItemId).Result.Name;
                result[i].UserName = _userRepository.GetById(result[i].UserId).Result.Name;
            }
            return result;
        }

        [HttpGet("item/{id}")]
        public async Task<List<ReviewDto>> GetByItem(Guid id)
        {
            var result = ReviewConverter.Convert(await _context.Review.Where(x => x.ItemId ==id ).ToListAsync());
            for (int i = 0; i < result.Count; i++)
            {
                result[i].KLikes = _context.Likes.Where(e => e.ReviewId == result[i].Id && e.Type == true).Count();
                result[i].KDisLikes = _context.Likes.Where(e => e.ReviewId == result[i].Id && e.Type == false).Count();
                result[i].ItemName = _itemRepository.GetByIdAsync(result[i].ItemId).Result.Name;
                result[i].UserName = _userRepository.GetById(result[i].UserId).Result.Name;
            }
            return result;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("user/{id}")]
        public async Task<List<ReviewDto>> GetByUser(Guid id)
        {
            var result = ReviewConverter.Convert(await _context.Review.Where(x => x.UserId == id).ToListAsync());
            for (int i = 0; i < result.Count; i++)
            {
                result[i].KLikes = _context.Likes.Where(e => e.ReviewId == result[i].Id && e.Type == true).Count();
                result[i].KDisLikes = _context.Likes.Where(e => e.ReviewId == result[i].Id && e.Type == false).Count();
                result[i].ItemName = _itemRepository.GetByIdAsync(result[i].ItemId).Result.Name;
                result[i].UserName = _userRepository.GetById(result[i].UserId).Result.Name;
            }
            return result;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            var item = await _context.Review.FindAsync(id);
            if (item == null)
                return false;
            _context.Review.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
        [Authorize]
        [HttpPut]
        public async Task<bool> Edit([FromBody] Review item)
        {
            var Item = await _context.Review.FirstOrDefaultAsync(x => x.Id == item.Id);
            if (Item == null)
                return false;
            Item.Img = item.Img;
            Item.Text = item.Text;
            _context.Review.Update(Item);
            await _context.SaveChangesAsync();
            return true;
        }


        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<bool>> SendAuth(
            [FromBody] ReviewDto review)
        {
            review.UserName = _userRepository.GetById(review.UserId).Result.Name;
            try
            {
                var email = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                await _authHubContext.Clients.All.SendAsync("Send", review.UserName, review.Text , review.UserId , review.ItemId , review.Id);

                await _context.Review.AddAsync(ReviewConverter.Convert(review));
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

    }
}
