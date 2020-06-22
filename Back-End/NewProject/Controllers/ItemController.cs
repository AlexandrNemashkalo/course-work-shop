using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Domain.Dto;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    public class ItemController :Controller
    {
        private readonly IItemRepository _repo;
        public ItemController(IItemRepository repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
                {return Ok(await _repo.GetAllAsync());}
            catch (Exception e)
                {return StatusCode(500, e);}
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            try
                {return Ok(await _repo.GetByIdAsync(id));}
            catch (Exception e)
                {return StatusCode(500, e);}
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ItemDto item)
        {
            try
                {return Ok(await _repo.CreateAsync(item));}
            catch (Exception e)
                {return StatusCode(500, e);}
        }
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ItemDto item)
        {
            try
                {return Ok(await _repo.UpdateAsync(item));}
            catch (Exception e)
                {return StatusCode(500, e);}
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
                {return Ok(await _repo.DeleteAsync(id));}
            catch (Exception e)
                {return StatusCode(500, e);}
        }

        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetByCategory(Guid id)
        {
            try
                {return Ok(await _repo.GetByCategoryAsync(id));}
            catch (Exception e)
                {return StatusCode(500, e);}
        }
    }
}
