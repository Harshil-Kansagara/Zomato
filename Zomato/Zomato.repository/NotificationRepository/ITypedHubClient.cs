using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.NotificationRepository
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(Order data);

    }
}
