using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Zomato.Repository.NotificationRepository
{
    public class NotifyHub : Hub<ITypedHubClient>
    {

        public override Task OnConnectedAsync()
       {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("Who is connected:" + Context.ConnectionId);
            Console.WriteLine("Claims Identifier:" + Context.UserIdentifier);
            Console.WriteLine("User:" + Context.User.Identity.Name);
            Console.WriteLine("----------------------------------------------------------");
            return base.OnConnectedAsync();
        }
    }
}
