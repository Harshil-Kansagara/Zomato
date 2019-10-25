using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.OrderedItemRepository
{
    public class OrderedItemRepository : IOrderedItemRepository
    {
        public async Task<OrderedItem> AddOrderedItem(OrderedItem orderedItem)
        {     
            throw new NotImplementedException();
        }    
        public async Task<List<OrderedItem>> GetOrderedItemByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
