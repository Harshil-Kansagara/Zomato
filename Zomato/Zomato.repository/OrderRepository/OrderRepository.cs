using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<Order> AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> GetOrderDataByOrderId(int orderId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetOrderListByRestaurantId(int restaurantId)
        {
            throw new NotImplementedException();
        }
    }
}
