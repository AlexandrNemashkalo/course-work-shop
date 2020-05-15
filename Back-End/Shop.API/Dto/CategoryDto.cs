using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Domain.Dto
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public List<ItemDto> Items { get; set; } = new List<ItemDto>();
    }
}
