using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.NotificationRepository
{
    public class OrderNotificationRepository : IOrderNotificationRepository
    {
        private ApplicationDbContext _db;

        public OrderNotificationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddConnectionId(NotificationHub notificationHub)
        {
            await _db.NotificationHub.AddAsync(notificationHub);
        }

        public async Task AddOrderDataForNotification(OrderNotificationData orderNotificationData)
        {
            await _db.OrderNotificationData.AddAsync(orderNotificationData);
        }

        public async Task<List<NotificationHub>> GetConnectionList()
        {
            return await _db.NotificationHub.ToListAsync();
        }

        public async Task<List<OrderNotificationData>> GetOrderNotification()
        {
            return await _db.OrderNotificationData.ToListAsync();
        }

        public async Task RemoveConnectionId(NotificationHub notificationHub)
        {
            var connectionList = await _db.NotificationHub.Where(x => x.UserId == notificationHub.UserId && x.ConnectionId == notificationHub.ConnectionId).FirstAsync();
            if(connectionList != null) { 
                _db.NotificationHub.Remove(connectionList);
            }
        }

        public async Task RemoveOrderNotificationData(int orderId)
        {
            var order = await _db.OrderNotificationData.Where(x => x.OrderId == orderId).FirstAsync();
            if (order != null)
            {
                _db.OrderNotificationData.Remove(order);
            }
        }
    }
}
