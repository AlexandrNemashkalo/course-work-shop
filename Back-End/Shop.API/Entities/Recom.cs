using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{
    public class Recom
    {
        public Guid UserId { get; set; }
        //public Guid ItemId { get; set; }
        public List<UserItem>? UserItems { get; set; } 

    }
}
