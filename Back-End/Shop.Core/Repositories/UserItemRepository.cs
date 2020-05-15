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
   public class UserItemRepository : IUserItemRepository
    {
        private readonly ShopContext _context;
        private readonly IItemRepository  _item;
        private readonly IUserRepository _user;
        private async Task<UserItemDto> Convert(UserItemDto ut)
        {
            var item = await _item.GetByIdAsync(ut.ItemId);
            var user = await _user.GetById(ut.UserId);
            ut.ItemName = item.Name;
            ut.ItemImg = item.Img;
            ut.ItemCost = item.Cost;
            ut.UserName = user.Name;
            ut.UserEmail = user.Email;
            return ut;
        }

        public UserItemRepository(ShopContext context , IItemRepository item, IUserRepository user)
        {
            _user = user;
            _item = item;
            _context = context;
        }

        public async Task<List<UserItemDto>> GetAllAsync()
        {
            List<UserItemDto> useritemdto = UserItemConverter.Convert(await _context.UserItems.ToListAsync());
            foreach(UserItemDto ut in useritemdto)
            {
                await Convert(ut);
            }

            return useritemdto;
        }

        public async Task<UserItemDto> GetByIdAsync(Guid id)
        {
            UserItemDto album = UserItemConverter.Convert(await _context.UserItems.FirstOrDefaultAsync(x => x.Id == id));
            return await Convert(album);
        }

        public async Task<UserItemDto> CreateAsync(UserItem item)
        {
            item.Id = Guid.NewGuid();
            var result = await _context.UserItems.AddAsync(item);
            await _context.SaveChangesAsync();
            return UserItemConverter.Convert(result.Entity);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var album = await _context.UserItems.FirstOrDefaultAsync(x => x.Id == id);
            if (album == null)
                return false;
            _context.UserItems.Remove(album);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ItemDto>> GetItemsByUserAsync(Guid userId)
        {
            List<UserItem> useritems = await _context.UserItems.Where(x => x.UserId == userId).ToListAsync();
            List<ItemDto> items = new List<ItemDto>();
            foreach (UserItem useritem in useritems)
            {
                items.Add(await _item.GetByIdAsync(useritem.ItemId));
            }
            return items;
        }



        public async Task<List<UserItemDto>> GetUserItemsByOrderAsync( int orderId)
        {
            List<UserItemDto> useritemsdto = UserItemConverter.Convert( await _context.UserItems.Where(x => x.OrderId == orderId).ToListAsync());
            foreach (UserItemDto ut in useritemsdto)
            {
                await Convert(ut);
            }
            return useritemsdto;
        }
        




        public async Task<List<UserItemDto>> GetUserItemsByUserAsync(Guid userId)
        {
            List<UserItemDto> useritems = UserItemConverter.Convert( await _context.UserItems.Where(x => x.UserId == userId).ToListAsync());
            foreach(var useritem in useritems)
            {
                await Convert(useritem);
            }
            return useritems;
        }


        public async Task<List<UserDto>> GetUsersByItemAsync(Guid itemId)
        {
            List<UserItem> useritems = await _context.UserItems.Where(x => x.ItemId == itemId).ToListAsync();
            List<UserDto> users = new List<UserDto>();
            foreach (UserItem useritem in useritems)
            {
                users.Add(await _user.GetById(useritem.UserId));
            }
            return users;
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
            UserItem.OrderId = useritem.OrderId;
            _context.UserItems.Update(UserItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public  async Task<List<UserItemDto>> GetAllByUserAsync(Guid userId)
        {
            List<UserItemDto> useritems = UserItemConverter.Convert(await _context.UserItems.Where(x => x.UserId == userId).ToListAsync());
            foreach (UserItemDto useritem in useritems)
            {
                await Convert(useritem);
            }
            return useritems;
        }





        public async Task<List<ItemDto>> GetRecommendationsAsync(Recom recom)
        {
            if (recom.UserItems.Count > 0)
            {
                List<Order> allOrders = _context.Orders.ToList();
                Dictionary<Guid, int> ITEMS = new Dictionary<Guid, int>();


                foreach (Order order in allOrders)
                {
                    List<UserItem> userItems = UserItemConverter.Convert(await GetUserItemsByOrderAsync(order.Id));
                    bool flag = true;
                    foreach (UserItem myUserItem in recom.UserItems)
                    {
                        if (userItems.FirstOrDefault(x => x.ItemId == myUserItem.ItemId) == null)
                        {
                            flag = false;
                        }
                    }

                    //UserItem tekush = userItems.FirstOrDefault(x => x.ItemId == recom.ItemId);
                    if (flag == true)
                    {
                        foreach (UserItem userItem in userItems)
                        {

                            if (recom.UserItems.FirstOrDefault(x => x.ItemId == userItem.ItemId) == null && ITEMS.ContainsKey(userItem.ItemId) == false)
                            {
                                ITEMS.Add(userItem.ItemId, 1);
                            }
                            else if (recom.UserItems.FirstOrDefault(x => x.ItemId == userItem.ItemId) == null && ITEMS.ContainsKey(userItem.ItemId) == true)
                            {
                                ITEMS[userItem.ItemId]++;
                            }
                        }
                    }
                }

                var myList = ITEMS.ToList();
                myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
                myList.Reverse();

                List<ItemDto> ItemsResult = new List<ItemDto>();
                foreach (var kvp in myList)
                {
                    ItemsResult.Add(await _item.GetByIdAsync(kvp.Key));
                }
                return ItemsResult;
            }
            return null;









            /*List<UserDto> users = (await GetUsersByItemAsync(recom.ItemId)).FindAll(x => x.Id != recom.UserId);
            Dictionary<Guid, int> ITEMS = new Dictionary<Guid, int>();
            List<ItemDto> MyItems = await GetItemsByUserAsync(recom.UserId);

            foreach (UserDto user in users)
            {
                List<ItemDto> items = await GetItemsByUserAsync(user.Id);
                Dictionary<Guid, int> IT = new Dictionary<Guid, int>();
                foreach (ItemDto item in items)
                {
                    if (item.Id != recom.ItemId && MyItems.FirstOrDefault(x => x.Id == item.Id) == null) {
                        if (ITEMS.ContainsKey(item.Id) == false && IT.ContainsKey(item.Id) == false)
                        {
                            ITEMS.Add(item.Id, 1);
                            IT.Add(item.Id, 1);
                        }
                        else if (ITEMS.ContainsKey(item.Id) == true && IT.ContainsKey(item.Id) == false)
                        {
                            IT.Add(item.Id, 1);
                            ITEMS[item.Id]++;
                        }
                    }
                }
            }*
            var myList = ITEMS.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            myList.Reverse();

            List<ItemDto> ItemsResult = new List<ItemDto>();
            foreach (var kvp in myList)
            {
                ItemsResult.Add(await _item.GetByIdAsync(kvp.Key));
            }
             return ItemsResult;*/
        }


            


    }
 }
