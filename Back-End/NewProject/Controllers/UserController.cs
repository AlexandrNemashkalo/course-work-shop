using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Interfaces;
using Shop.Domain.Dto;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller, IUser
    {
        private readonly IUserRepository _repo;
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            try
            {
                return Ok(await _repo.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

  
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            try
            {
                UserDto user = await _repo.GetById(id);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserDto>> GetByEmail(string email)
        {
            try
            {
                UserDto user = await _repo.GetByEmail(email);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDto item)
        {
            try
            {
                UserDto user = await _repo.Create(item);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<ActionResult<bool>> Put([FromBody] UserDto item)
        {
            try
            {
                return await _repo.Update(item);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            try
            {
                return await _repo.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
