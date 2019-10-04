using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.FollowRepository
{
    public interface IFollowRepository
    {
        List<Follow> GetFollowersByUserId(string userId);
        List<Follow> GetFollowingFromFollowerId(string userId);
        Follow AddFollower(Follow follow);
    }
}
