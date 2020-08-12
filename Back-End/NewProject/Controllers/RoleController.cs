using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Interfaces;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    public class RoleController : Controller, IRole
    {
        private readonly IRoleRepository _repo;
        public RoleController(IRoleRepository repo)
        {
            _repo = repo;
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<List<IdentityRole<Guid>>>> Get()
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

        [Authorize(Roles = "admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityRole<Guid>>> Get(Guid id)
        {
            try
            {
                IdentityRole<Guid> user = await _repo.GetById(id);
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
        [HttpGet("email/{email}")]
        public async Task<ActionResult<IdentityRole<Guid>>> GetByEmai(string email)
        {
            try
            {
                IdentityRole<Guid> user = await _repo.GetByName(email);
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
        public async Task<ActionResult<IdentityRole<Guid>>> Post([FromBody] IdentityRole<Guid> item)
        {
            try
            {
                IdentityRole<Guid> user = await _repo.Create(item);
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
        public async Task<ActionResult<bool>> Put([FromBody] IdentityRole<Guid> item)
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
