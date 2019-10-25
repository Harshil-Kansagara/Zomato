using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.FollowRepository
{
    public interface IFollowRepository
    {
        Task<List<Follow>> GetFollowersByUserId(string userId);
        Task<List<Follow>> GetFollowingFromFollowerId(string userId);
        Task<Follow> AddFollower(Follow follow);
    }
}
