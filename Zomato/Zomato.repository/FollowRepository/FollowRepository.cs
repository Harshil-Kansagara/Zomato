using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.FollowRepository
{
    public class FollowRepository : IFollowRepository
    {
        public async Task<Follow> AddFollower(Follow follow)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Follow>> GetFollowersByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Follow>> GetFollowingFromFollowerId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
