using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain.Converters
{
    public static class CategoryConverter
    {

        public static CategoryDto Convert(Category item)
        {
            return new CategoryDto
            {
                Id = item.Id,
                Name = item.Name,
                Img =item.Img,
                Items = ItemConverter.Convert(item.Items)
            };
        }

        public static Category Convert(CategoryDto item)
        {
            return new Category
            {
                Id = item.Id,
                Img = item.Img,
                Name = item.Name,
         
                Items = ItemConverter.Convert(item.Items)


            };
        }
        public static List<CategoryDto> Convert(List<Category> categories)
        {
            return categories.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }

        public static List<Category> Convert(List<CategoryDto> categories)
        {
            return categories.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }
    }
}
