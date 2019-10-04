using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        public Order AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderDataByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrderListByRestaurantId(int restaurantId)
        {
            throw new NotImplementedException();
        }
    }
}
