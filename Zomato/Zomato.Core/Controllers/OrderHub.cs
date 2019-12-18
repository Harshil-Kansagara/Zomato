using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;
using Zomato.Repository.UnitofWork;

namespace Zomato.Core.Controllers
{
    public class OrderHub : Hub
    {
        //private readonly static ConnectionMapping<string> _connections =
        //new ConnectionMapping<string>();

        private IUnitOfWork _unitOfWork;

        public OrderHub(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task DeliveryOrder(string userId)
        {
            var connectionList = await _unitOfWork.OrderNotificationRepository.GetConnectionList();
            foreach (var each in connectionList)
            {
                if(each.UserId == userId)
                {
                    await Clients.Client(each.ConnectionId).SendAsync("DeliverySuccessful", "Delivered Order");
                }
            }
            //var connectionId = _connections.GetConnections("4aa56cd4-3ac4-4be0-af99-5933372d8a22");
            //foreach (var id in _connections.GetConnections("4aa56cd4-3ac4-4be0-af99-5933372d8a22"))
            //{
            //    await Clients.Client(id).SendAsync("OrderReceived", order);
            //}
            //await Clients.Client(connectionId.ToString()).SendAsync("OrderReceived", order);
        }

        public override async Task OnConnectedAsync()
        {
            if(Context.User.Identity.Name != null)
            {
                NotificationHub notificationHub = new NotificationHub();
                notificationHub.UserId = Context.User.Identity.Name;
                notificationHub.ConnectionId = Context.ConnectionId;
                await _unitOfWork.OrderNotificationRepository.AddConnectionId(notificationHub);
                _unitOfWork.commit();
            }
           // return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if(Context.User.Identity.Name != null)
            {
                NotificationHub notificationHub = new NotificationHub();
                notificationHub.UserId = Context.User.Identity.Name;
                notificationHub.ConnectionId = Context.ConnectionId;
                await _unitOfWork.OrderNotificationRepository.RemoveConnectionId(notificationHub); 
                _unitOfWork.commit();
            }
           // return base.OnDisconnectedAsync(exception);
        }

        
    }
}
//var userId = Context.User.Identity.Name;
//if (Context.User.Identity.Name != null) { 
//_connections.Add(Context.User.Identity.Name, Context.ConnectionId);
//}

//if(Context.User.Identity.Name != null) { 
//_connections.Remove(Context.User.Identity.Name, Context.ConnectionId);
//}