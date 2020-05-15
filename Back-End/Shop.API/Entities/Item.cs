using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Text { get; set; }
        public int Cost { get; set; }
        public Guid? UserId { get; set; }
        public int Views { get; set; }
        public int? Grams { get; set; }
        public bool Status { get; set; }
        public bool Komplex { get; set; } = false;
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public Guid CategoryId { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<UserItem> UserItems { get; set; } = new List<UserItem>();
        public List<Rating> Ratings { get; set; } = new List<Rating>();
        // public string LongText { get; set; }

    }
}

