using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.OrderedItemRepository
{
    public class OrderedItemRepository : IOrderedItemRepository
    {
        private ApplicationDbContext _db;

        public OrderedItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<OrderedItem> AddOrderedItem(OrderedItem orderedItem)
        {
            await _db.OrderedItem.AddAsync(orderedItem);
            return orderedItem;
        }

        public async Task DeleteOrderItem(int orderId)
        {
            var orderItem = await _db.OrderedItem.Where(x => x.OrderId == orderId).ToListAsync();
            foreach(var each in orderItem)
            {
                _db.OrderedItem.Remove(each);
            }
        }

        public async Task<List<OrderedItem>> GetOrderedItemByOrderId(int orderId)
        {
            return await _db.OrderedItem.Where(x => x.OrderId == orderId).ToListAsync();
            
        }
    }
}
