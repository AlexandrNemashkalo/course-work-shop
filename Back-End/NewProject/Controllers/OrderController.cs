﻿using Microsoft.AspNetCore.Authorization;
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
    public class OrderController : Controller, IOrder
    {
        private readonly IOrderRepository _repo;
        public OrderController(IOrderRepository repo)
        {
            _repo = repo;
        }

        [Authorize(Roles="admin")]
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
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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
        [HttpGet("user/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _repo.GetOrderByUserAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order item)
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
        public async Task<IActionResult> Delete(int id)
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
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Order useritem)
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

        /*[HttpGet("users/{id}")]
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
        */







    }
}
