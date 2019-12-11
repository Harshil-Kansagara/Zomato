using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.NotificationRepository
{
    public class OrderHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
        new ConnectionMapping<string>();

        public async Task NewOrder(Order order)
        {
            //var connectionId = _connections.GetConnections("4aa56cd4-3ac4-4be0-af99-5933372d8a22");
            foreach (var id in _connections.GetConnections("4aa56cd4-3ac4-4be0-af99-5933372d8a22"))
            {
                await Clients.Client(id).SendAsync("OrderReceived", order);
            }
            //await Clients.Client(connectionId.ToString()).SendAsync("OrderReceived", order);
        }

        public override Task OnConnectedAsync()
        {
            //var userId = Context.User.Identity.Name;
            if (Context.User.Identity.Name != null) { 
            _connections.Add(Context.User.Identity.Name, Context.ConnectionId);
            }
            Console.WriteLine("Who is connected:" + Context.ConnectionId);
            Console.WriteLine("User:" + Context.User.Identity.Name);
            return base.OnConnectedAsync();
        }

    }
}
