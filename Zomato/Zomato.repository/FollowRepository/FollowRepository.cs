using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.FollowRepository
{
    public class FollowRepository : IFollowRepository
    {
        public Follow AddFollower(Follow follow)
        {
            throw new NotImplementedException();
        }

        public List<Follow> GetFollowersByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public List<Follow> GetFollowingFromFollowerId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
