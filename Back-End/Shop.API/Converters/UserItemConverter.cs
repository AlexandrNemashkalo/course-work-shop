using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain.Converters
{
    public static class UserItemConverter
    {
        public static UserItemDto Convert(UserItem item)
        {
            return new UserItemDto
            {
                UserId = item.UserId,
                Id = item.Id,
                ItemId = item.ItemId,
                
                //ItemName = item.ItemName,
                Status = item.Status,
                Date =item.Date,
                Value =item.Value,
                OrderId =item.OrderId


                // Items =item.Items

            };
        }

        public static UserItem Convert(UserItemDto item)
        {
            return new UserItem
            {
                //Items = item.Items,
                UserId = item.UserId,
                Id = item.Id,
                ItemId = item.ItemId,
                //ItemName = item.ItemName,
                Status = item.Status,
                Date = item.Date,
                Value = item.Value,
                OrderId = item.OrderId


            };
        }
        public static List<UserItemDto> Convert(List<UserItem> items)
        {
            return items.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }

        public static List<UserItem> Convert(List<UserItemDto> albums)
        {
            return albums.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }
        
    }
}
