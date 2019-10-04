using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.OrderedItemRepository
{
    public interface IOrderedItemRepository
    {
        OrderedItem AddOrderedItem(OrderedItem orderedItem);
        List<OrderedItem> GetOrderedItemByOrderId(int orderId);
    }
}
