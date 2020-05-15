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
    public class RatingController : Controller
    {
        private readonly IRatingRepository _repo;
        public RatingController(IRatingRepository repo)
        {
            _repo = repo;
        }


        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _repo.GetAllRatingsAsync());
            }
            catch (Exception e)
            {
                return StatusCode(525, e);
            }
        }


        [Authorize(Roles = "admin")]
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
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetRatingsByUser(Guid id)
        {
            try
            {
                return Ok(await  _repo.GetRatingsByUserAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetRatingsByItem(Guid id)
        {
            try
            {
                return Ok( await _repo.GetRatingsByItemAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rating item)
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
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Rating item)
        {
            try
            {
                return Ok(await _repo.UpdateAsync(item));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }





    }
}
