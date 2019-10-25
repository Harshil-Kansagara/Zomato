using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.OrderRepository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
        Task<Order> GetOrderDataByOrderId(int orderId);
        Task<List<Order>> GetOrderListByRestaurantId(int restaurantId);
    }
}
