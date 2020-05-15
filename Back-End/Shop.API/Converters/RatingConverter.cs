using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain.Converters
{
    public static class RatingConverter
    {
        public static RatingDto Convert(Rating item)
        {
            return new RatingDto
            {
                Id = item.Id,
                UserId = item.UserId,
                ItemId = item.ItemId,
                Star =item.Star,
                Date = item.Date

            };
        }

        public static Rating Convert(RatingDto item)
        {
            return new Rating
            {
                Id = item.Id,
                UserId = item.UserId,
                ItemId = item.ItemId,
                Star = item.Star,
                Date = item.Date
            };
        }
        public static List<RatingDto> Convert(List<Rating> items)
        {
            return items.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }

        public static List<Rating> Convert(List<RatingDto> albums)
        {
            return albums.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }
    }
}
