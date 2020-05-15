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
    public class LikeController : Controller
    {

        private readonly ILikeRepository _repo;
        public LikeController(ILikeRepository repo)
        {
            _repo = repo;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _repo.GetLikesByReviewAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Like item)
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
        public async Task<IActionResult> Put([FromBody] Like item)
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
