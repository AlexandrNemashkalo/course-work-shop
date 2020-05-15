using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<UserItem> UserItems { get; set; } = new List<UserItem>();
        public List<RefreshToken> Tokens { get; set; } = new List<RefreshToken>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();
        public List<Like> Likes { get; set; } = new List<Like>();
    

    }
}
