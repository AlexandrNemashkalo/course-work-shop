using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Core.EF
{
    public class ShopContext:  IdentityDbContext<User,IdentityRole<Guid>,Guid>
    {
    
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<UserItem> UserItems { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>[]
                {
                    new IdentityRole<Guid>
                    {
                        Id=Guid.NewGuid(),
                        Name="user",
                        NormalizedName="USER"
                    },
                    new IdentityRole<Guid>
                    {
                        Id=Guid.NewGuid(),
                        Name="admin",
                        NormalizedName="ADMIN"
                    }
                });

            builder.Entity<RefreshToken>()
                .HasKey(rt => new { rt.UserId, rt.Token });

            base.OnModelCreating(builder);
        }

        public ShopContext(DbContextOptions<ShopContext> opt) : 
            base(opt)
        {
            Database.EnsureCreated();
        }
    }
}
