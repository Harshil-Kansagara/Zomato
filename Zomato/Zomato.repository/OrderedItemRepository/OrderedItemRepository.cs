using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.OrderedItemRepository
{
    public class OrderedItemRepository : IOrderedItemRepository
    {
        public OrderedItem AddOrderedItem(OrderedItem orderedItem)
        {
            throw new NotImplementedException();
        }

        public List<OrderedItem> GetOrderedItemByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
