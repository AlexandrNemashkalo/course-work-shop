

using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{
    public class Rating
    {

        public Guid Id { get; set; }
        public int Star { get; set; }
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

    }
}
