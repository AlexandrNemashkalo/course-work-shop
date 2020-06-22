using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain.Converters
{
    public static class ItemConverter
    {
        public static ItemDto Convert(Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                CategoryId = item.CategoryId,
                DateCreate = item.DateCreate,
                Name = item.Name,
                Img = item.Img,
                Text = item.Text,
                Cost = item.Cost,
                Views = item.Views,
                Grams = item.Grams,
                Status = item.Status,
                Komplex =item.Komplex
            };
        }
        public static Item Convert(ItemDto item)
        {
            return new Item
            {
                Id = item.Id,
                CategoryId = item.CategoryId,
                DateCreate = item.DateCreate,
                Name = item.Name,
                Img = item.Img,
                Text = item.Text,
                Cost = item.Cost,
                Views = item.Views,
                Grams = item.Grams,
                Status = item.Status,
                Komplex = item.Komplex
            };
        }
        public static List<ItemDto> Convert(List<Item> items)
        {
            return items.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }

        public static List<Item> Convert(List<ItemDto> albums)
        {
            return albums.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }
    }
}
