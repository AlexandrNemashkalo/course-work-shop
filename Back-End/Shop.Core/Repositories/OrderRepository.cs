using Microsoft.EntityFrameworkCore;
using Shop.Core.EF;
using Shop.Domain.Converters;
using Shop.Domain.Dto;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public class OrderRepository :IOrderRepository
    {
        private readonly ShopContext _context;
        private readonly IUserItemRepository _ui;
        private readonly IUserRepository _user;
        private async Task<OrderDto> Convert(OrderDto ut)
        {
            var user = await _user.GetById(ut.UserId);
            //ut.Cost = ut.Cost;
            var list = await _ui.GetUserItemsByOrderAsync(ut.Id);
            ut.Cost = 0;
            foreach(var lis in list)
            {   

                ut.Cost = ut.Cost + lis.ItemCost * lis.Value;
            }
            ut.UserName = user.Name;
            return ut;
        }

        public OrderRepository(ShopContext context, IUserItemRepository ui, IUserRepository user)
        {
            _user = user;
            _ui = ui;
            _context = context;
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            List<OrderDto> orderdto = OrderConverter.Convert(await _context.Orders.ToListAsync());
            foreach (OrderDto ut in orderdto)
            {
                await Convert(ut);
                ut.UserItems = await _ui.GetUserItemsByOrderAsync(ut.Id);
            }

            return orderdto;
        }

        public async Task<OrderDto> GetByIdAsync(int id)
        {
           OrderDto album = OrderConverter.Convert(await _context.Orders.FirstOrDefaultAsync(x => x.Id == id));
           return await Convert(album);
        }

        public async Task<OrderDto> CreateAsync(Order item)
        {
            //item.Id = Guid.NewGuid();
            var result = await _context.Orders.AddAsync(item);
            await _context.SaveChangesAsync();
            return OrderConverter.Convert(result.Entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var album = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (album == null)
                return false;
            _context.Orders.Remove(album);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Order useritem)
        {
            var UserItem = await _context.Orders.FirstOrDefaultAsync(x => x.Id == useritem.Id);
            if (UserItem == null)
            {
                return false;
            }
            UserItem.Status = useritem.Status;
            UserItem.Show = useritem.Show;
            UserItem.Date = DateTime.Now;
            UserItem.Komplex = useritem.Komplex;
            _context.Orders.Update(UserItem);
            await _context.SaveChangesAsync();
            return true;
        }





        public async Task<List<OrderDto>> GetOrderByUserAsync(Guid userId)
        {
            List<OrderDto> useritems = OrderConverter.Convert( await _context.Orders.Where(x => x.UserId == userId).ToListAsync());
            foreach (OrderDto useritem in useritems)
            {
                await Convert(useritem);
                useritem.UserItems = await _ui.GetUserItemsByOrderAsync(useritem.Id);
            }
            return useritems;
        }



        /*public async Task<List<UserItemDto>> GetUserItemsByOrderAsync(int orderId)
        {
            List<UserItemDto> useritemsdto = UserItemConverter.Convert(await _context.UserItems.Where(x => x.OrderId == orderId).ToListAsync());
            foreach (UserItemDto ut in useritemsdto)
            {
                await Convert(ut);
            }
            return useritemsdto;
        }



        public async Task<bool> UpdateAsync(UserItem useritem)
        {
            var UserItem = await _context.UserItems.FirstOrDefaultAsync(x => x.Id == useritem.Id);
            if (UserItem == null)
            {
                return false;
            }
            UserItem.Status = useritem.Status;
            UserItem.Value = useritem.Value;
            _context.UserItems.Update(UserItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserItemDto>> GetAllByUserAsync(Guid userId)
        {
            List<UserItemDto> useritems = UserItemConverter.Convert(await _context.UserItems.Where(x => x.UserId == userId).ToListAsync());
            foreach (UserItemDto useritem in useritems)
            {
                await Convert(useritem);
            }
            return useritems;
        }*/


 




    }
}
