using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Dto
{
    public class UserDto
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool EmailConfirmed { get; set;  }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<UserItemDto> UserItems { get; set; } = new List<UserItemDto>();
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();
        public List<Like> Likes { get; set; } = new List<Like>();
     
        // public List<Item> Items { get; set; } = new List<Item>();

    }
}
