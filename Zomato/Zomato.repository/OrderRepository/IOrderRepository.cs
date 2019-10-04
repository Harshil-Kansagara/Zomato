using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.OrderRepository
{
    public interface IOrderRepository
    {
        Order AddOrder(Order order);
        Order GetOrderDataByOrderId(int orderId);
        List<Order> GetOrderListByRestaurantId(int restaurantId);
    }
}
