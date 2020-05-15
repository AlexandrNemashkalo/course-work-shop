using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{
    public class UserItem
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public int? OrderId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int Value { get; set; }


    }
}
