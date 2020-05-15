using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain.Converters
{
    public static class ReviewConverter
    {
        public static ReviewDto Convert(Review item)
        {
            return new ReviewDto
            {
                Id = item.Id,
                UserId = item.UserId,
                Date = item.Date,
                Img = item.Img,
                Text = item.Text,
                ItemId =item.ItemId
               
            };
        }

        public static Review Convert(ReviewDto item)
        {
            return new Review
            {
                Id = item.Id,
                UserId = item.UserId,
                Img = item.Img,
                Text = item.Text,
                ItemId = item.ItemId,
                Date = item.Date


            };
        }
        public static List<ReviewDto> Convert(List<Review> items)
        {
            return items.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }

        public static List<Review> Convert(List<ReviewDto> albums)
        {
            return albums.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }
    }
}
