using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Interfaces;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller, INews
    {
        private readonly INewsRepository _repo;

        public NewsController(INewsRepository repo)
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
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] News ev)
        {
            try
            {
                return Ok(await _repo.UpdateAsync(ev));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] News ev)
        {
            try
            {
                return Ok(await _repo.CreateAsync(ev));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }





    }

}
