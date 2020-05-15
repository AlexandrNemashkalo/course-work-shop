using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Img { get; set; }
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public List<Like> Likes { get; set; } = new List<Like>();
 
    }
}
