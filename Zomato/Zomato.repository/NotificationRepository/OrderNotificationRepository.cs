using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;
using Zomato.Repository.DataRepository;

namespace Zomato.Repository.NotificationRepository
{
    public class OrderNotificationRepository : IOrderNotificationRepository
    {
        private IDataRepository _dataRepository;

        public OrderNotificationRepository(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task AddConnectionId(NotificationHub notificationHub)
        {
            await _dataRepository.AddAsync(notificationHub);
        }

        public async Task AddOrderDataForNotification(OrderNotificationData orderNotificationData)
        {
            await _dataRepository.AddAsync(orderNotificationData);
        }

        public async Task<List<NotificationHub>> GetConnectionList()
        {
            return await _dataRepository.Get<NotificationHub>();
        }

        public async Task<List<OrderNotificationData>> GetOrderNotification()
        {
            return await _dataRepository.Get<OrderNotificationData>();
        }

        public async Task RemoveConnectionId(NotificationHub notificationHub)
        {
            var connectionList = await _dataRepository.Where<NotificationHub>(x => x.UserId == notificationHub.UserId && x.ConnectionId == notificationHub.ConnectionId).FirstAsync();
            if(connectionList != null) {
                _dataRepository.Remove(connectionList);
            }
        }

        public async Task RemoveOrderNotificationData(int orderId)
        {
            var order = await _dataRepository.Where<OrderNotification>(x => x.OrderId == orderId).FirstAsync();
            if (order != null)
            {
                _dataRepository.Remove(order);
            }
        }
    }
}
