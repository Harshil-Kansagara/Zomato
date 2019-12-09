using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.NotificationRepository
{
    public class OrderHub : Hub
    {
        public async Task NewOrder(Order order)
        {
            await Clients.All.SendAsync("OrderReceived", order);
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Who is connected:" + Context.ConnectionId);
            Console.WriteLine("Claims Identifier:" + Context.UserIdentifier);
            Console.WriteLine("User:" + Context.User);
            Console.WriteLine("----------------------------------------------------------");
            return base.OnConnectedAsync();
        }
    }
}
