using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Dto
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Text { get; set; }
        public int Cost { get; set; }
        public int Views { get; set; }
        public int? Grams { get; set; }
        public bool Status { get; set; }
        public int? KStars { get; set; }
        public int? Stars { get; set; }
        public bool Komplex { get; set; } = false;
        public Guid CategoryId { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public List<UserItemDto> UserItems { get; set; } = new List<UserItemDto>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();
       
    }
}
