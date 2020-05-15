using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    public class UserItemController : Controller
    {
        private readonly IUserItemRepository _repo;
        public UserItemController(IUserItemRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _repo.GetAllAsync());
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _repo.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Authorize]
        [HttpGet("order/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await _repo.GetUserItemsByOrderAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserItem item)
        {
            try
            {
                return Ok(await _repo.CreateAsync(item));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                return Ok(await _repo.DeleteAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpGet("users/{id}")]
        public async Task<IActionResult> GetUsers(Guid id)
        {
            try
            {
                return Ok(await _repo.GetUsersByItemAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpGet("items/{id}")]
        public async Task<IActionResult> GetItems(Guid id)
        {
            try
            {
                return Ok(await _repo.GetItemsByUserAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserItem useritem)
        {
            try
            {
                return Ok(await _repo.UpdateAsync(useritem));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [HttpGet("useritem/{id}")]
        public async Task<IActionResult> GetAllByUser(Guid id)
        {
            try
            {
                return Ok(await _repo.GetAllByUserAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        
        [HttpPost("recom/")]
        public async Task<IActionResult> GetRecommendations([FromBody] Recom recom)
        {
            try
            {
                return Ok(await _repo.GetRecommendationsAsync(recom));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Authorize]
        [HttpGet("useritems/{id}")]
        public async Task<IActionResult> GetUserItemsByUser(Guid id)
        {
            try
            {
                return Ok(await _repo.GetUserItemsByUserAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }



     




    }
}
