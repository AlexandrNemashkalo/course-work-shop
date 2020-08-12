using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Range(1, 50, ErrorMessage = "Недопустимое число")]
        public int Value { get; set; }


    }
}
