using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Dto
{
    public class OrderDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public List<UserItemDto> UserItems { get; set; } = new List<UserItemDto>();
        public DateTime Date { get; set; } = DateTime.Now;
        public string Status { get; set; }
        public int Cost { get; set; }
        public string UserName { get; set; }
        public bool Show { get; set; }
        public bool Komplex { get; set; } = false;
    }
}
