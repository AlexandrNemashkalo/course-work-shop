using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
