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
            builder.Entity<Category>().HasData(
                new Category[]
                {
                    new Category
                    {
                        Id=new Guid("aa01b477-8d72-47a2-9b24-1af6955fffc4"),
                        Name="Первые блюда",
                        Img = "/images/category/1.png"       
                    },
                    new Category
                    {
                        Id=Guid.NewGuid(),
                        Name=" Гарниры",
                        Img = "/images/category/2.png"
                    },
                    new Category
                    {
                        Id=Guid.NewGuid(),
                        Name="Салаты",
                        Img = "/images/category/Салат.png"
                    },
                    new Category
                    {
                        Id=Guid.NewGuid(),
                        Name="Мясо",
                        Img = "/images/category/Мясо.png"
                    },
                    new Category
                    {
                        Id=Guid.NewGuid(),
                        Name="Рыба",
                        Img = "/images/category/Рыба.png"
                    },
                    new Category
                    {
                        Id=new Guid("bb01a477-8d72-47a2-9b24-1af6955ffcc4"),
                        Name="Прочее",
                        Img = "/images/category/Супер.png"
                    },
                    new Category
                    {
                        Id=Guid.NewGuid(),
                        Name="Горячие напитки",
                        Img = "/images/category/Гнапитки.png"
                    },
                    new Category
                    {
                        Id=Guid.NewGuid(),
                        Name="Холодные напитки",
                        Img = "/images/category/напитки.png"
                    },
                    new Category
                    {
                        Id=Guid.NewGuid(),
                        Name="Сладкое",
                        Img = "/images/category/Мед.png"
                    },
                    new Category
                    {
                        Id=Guid.NewGuid(),
                        Name="Выпечка",
                        Img = "/images/category/Выпечка.png"
                    },
                    new Category
                    {
                        Id=Guid.NewGuid(),
                        Name="Пицца",
                        Img = "/images/category/Пица.png"
                    },
                    new Category
                    {
                        Id=Guid.NewGuid(),
                        Name="Закуски",
                        Img = "/images/category/бургер.png"
                    },

                });


            builder.Entity<Item>().HasData(
                new Item[]
                {
                    new Item
                    {
                        Id = new Guid("aa01a477-8d72-47a2-9b24-1af6955ffcc4"),
                        Name ="Комплекс",
                        Img = "/images/item/komplex.jpg",
                        CategoryId = new Guid("bb01a477-8d72-47a2-9b24-1af6955ffcc4"),
                        Cost = 120,
                        Views = 0,
                        Text = "Вкуснота",
                        Status = true,
                        Komplex = false
                    },
                    new Item
                    {
                        Id = Guid.NewGuid(),
                        Name ="Борщец",
                        Img = "/images/item/борщ.jpg",
                        CategoryId = new Guid("aa01b477-8d72-47a2-9b24-1af6955fffc4"),
                        Cost = 100,
                        Views = 0,
                        Text = "Вкуснота фе",
                        Status = false,
                        Komplex = false
                    },
                    new Item
                    {
                        Id = Guid.NewGuid(),
                        Name ="Супец",
                        Img = "/images/item/супец.jpg",
                        CategoryId = new Guid("aa01b477-8d72-47a2-9b24-1af6955fffc4"),
                        Cost = 90,
                        Views = 0,
                        Text = "Вкуснота ммм",
                        Status = true,
                        Komplex = true
                    },
                });

            builder.Entity<News>().HasData(
                new News[]
                {
                    new News
                    {
                        Id= Guid.NewGuid(),
                        Img = "/images/news/1.jpg",
                        Text ="Что-то очень интересное",
                        Link  = "https://vk.com/eeeengineer"
                    },
                    new News
                    {
                        Id= Guid.NewGuid(),
                        Img = "/images/news/2.jpg",
                        Text ="Что-то супер интересное",
                        Link  = "https://vk.com/eeeengineer"
                    },
                    new News
                    {
                        Id= Guid.NewGuid(),
                        Img = "/images/news/3.jpeg",
                        Text ="Что-то very интересное",
                        Link  = "https://vk.com/eeeengineer"
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
