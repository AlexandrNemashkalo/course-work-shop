using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Dto
{
    public class UserItemDto
    {
        public Guid Id { get; set; }
        public bool Status { get; set; }
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int? OrderId { get; set; }
        public int Value { get; set; }


        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string ItemName { get; set; }
        public string ItemImg { get; set; }
        public int ItemCost { get; set; }
    }
}
