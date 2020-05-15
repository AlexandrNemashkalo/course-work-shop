using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{
    public class Like
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ReviewId { get; set; } 
        public bool Type { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
