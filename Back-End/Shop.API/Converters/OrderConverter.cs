using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain.Converters
{
    public static  class OrderConverter
    {
        public static OrderDto Convert(Order item)
        {
            return new OrderDto
            {
                Id = item.Id,
                UserId = item.UserId,
                Date = item.Date,
                Status =item.Status,
                Show = item.Show,
               Komplex = item.Komplex
            };
        }

        public static Order Convert(OrderDto item)
        {
            return new Order
            {
                Id = item.Id,
                UserId = item.UserId,
                Date = item.Date,
                Status = item.Status,
                Show = item.Show,
                Komplex =item.Komplex

            };
        }
        public static List<OrderDto> Convert(List<Order> items)
        {
            return items.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }

        public static List<Order> Convert(List<OrderDto> albums)
        {
            return albums.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }
    }
}
