using Microsoft.AspNetCore.Identity;
using Shop.Domain.Dto;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop.Domain.Converters
{
    public static  class UserConverter
    {
     
        public static UserDto Convert(User item)
        {
            return new UserDto
            {
                Email = item.Email,
                Id = item.Id,
                Name = item.Name,
                Surname =item.Surname,
                EmailConfirmed = item.EmailConfirmed


                // Items =item.Items

            };
        }

        public static User Convert(UserDto item)
        {
            return new User
            {
                //Items = item.Items,
                Id = item.Id,
                Email = item.Email,
                Name = item.Name,
                Surname = item.Surname,
                UserName = item.Email,
                EmailConfirmed = item.EmailConfirmed
            };
        }
        public static List<UserDto> Convert(List<User> items)
        {
            return items.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }

        public static List<User> Convert(List<UserDto> albums)
        {
            return albums.Select(a =>
            {
                return Convert(a);
            }).ToList();
        }
        public static void  Convert(User item,UserDto itemDto )
        {
            item.Name = itemDto.Name;
            item.Surname = itemDto.Surname;
        }
    }
}
