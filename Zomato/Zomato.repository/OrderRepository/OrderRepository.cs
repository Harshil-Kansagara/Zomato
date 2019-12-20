using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _db.Order.AddAsync(order);
            return order;
        }

        public async Task DeleteOrder(int orderId)
        {
            var order = await _db.Order.FindAsync(orderId);
            if (order != null)
            {
                _db.Order.Remove(order);
            }
        }

        public async Task DeleteOrderByRestaurant(int restaurantId)
        {
            var orderList = await _db.Order.Where(x=>x.RestaurantId == restaurantId).ToListAsync();
            if (orderList != null)
            {
                foreach (var order in orderList)
                {
                    _db.Order.Remove(order);
                }
            }
        }

        public async Task<Order> GetOrderDataByOrderId(int orderId)
        {
            return await _db.Order.FindAsync(orderId);
        }

        public async Task<List<Order>> GetOrdersByRestaurantId(int restaurantId)
        {
            return await _db.Order.Where(x => x.RestaurantId == restaurantId).OrderByDescending(x => x.OrderDate).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByUserId(string userId)
        {
            return await _db.Order.Where(x => x.UserId == userId).OrderByDescending(x=>x.OrderDate).ToListAsync();
        }

        public async Task<int> GetRestaurantIdByOrderId(int orderId)
        {
            var a = await _db.Order.Where(x => x.OrderId == orderId).FirstAsync();
            return a.RestaurantId;
        }

        public async Task<string> GetUserIdByOrderId(int orderId)
        {
            var a = await _db.Order.Where(x => x.OrderId == orderId).FirstAsync();
            return a.UserId;
        }
    }
}
