using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Dto
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Img { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string UserName { get; set; }
        public string ItemName { get; set; }
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public List<Like> Likes { get; set; } = new List<Like>();
        public int? KLikes { get; set; }
        public int? KDisLikes { get; set; }

    
    }
}
