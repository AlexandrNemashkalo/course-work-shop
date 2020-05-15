using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public List<UserItem> UserItems { get; set; } = new List<UserItem>();
        public DateTime Date { get; set; } = DateTime.Now;
        public bool Show { get; set; }
        public string Status { get; set; }
        public bool Komplex { get; set; } = false;


    }
}
