using DataLayer.Database;
using DataLayer.Interface;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ItemRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> AddItem(ItemDTO itemDto)
        {
            if (itemDto == null)
            {
                return false;
            }
            Item item = new Item()
            {
                Name = itemDto.Name,
                Description = itemDto.Description,
                Quantity = itemDto.Quantity,
                Discount = itemDto.Discount,
                UnitPrice = itemDto.UnitPrice,
                Amount = itemDto.Quantity * itemDto.UnitPrice
            };
            _applicationDbContext.Items.Add(item);
            var result = await _applicationDbContext.SaveChangesAsync();

            return result > 0;
        }
        public async Task<List<Item>> GetItems()
        {
            List<Item> items = new List<Item>();    

            var data = from item in _applicationDbContext.Items
                       select new Item()
                       {
                           Name = item.Name,
                           Description = item.Description,
                           Quantity = item.Quantity,
                           Discount = item.Discount,
                           UnitPrice = item.UnitPrice,
                           Amount = item.Amount,
                       };
            return data.ToList();
        }

        public async Task<bool> UpdateItem(Item item)
        {
            var itm = await _applicationDbContext.Items.FirstOrDefaultAsync(itm => itm.ItemID == item.ItemID);
            if (itm == null)
            {
                return false;
            }
            _applicationDbContext.Items.Update(itm);
            var result = await _applicationDbContext.SaveChangesAsync();
            return result > 0;
        }

    }
}
