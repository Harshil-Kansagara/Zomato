using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.FollowRepository
{
    public class FollowRepository : IFollowRepository
    {
        private ApplicationDbContext _db;

        public FollowRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Follow> AddFollower(Follow follow)
        {
            await _db.Follow.AddAsync(follow);
            return follow;
        }

        public async Task<List<Follow>> GetFollowingByUserId(string userId)
        {
            return await _db.Follow.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<Follow>> GetFollowerByUserId(string userId)
        {
            
            return await _db.Follow.Where(x => x.FollowingId == userId).ToListAsync();
        }

        public async Task<List<Follow>> GetFollowList()
        {
            return await _db.Follow.ToListAsync();
        }

        public async Task RemoveFollower(string followerId)
        {
            var follower = await _db.Follow.Where(x => x.FollowingId == followerId).FirstAsync();
            if (follower != null)
            {
                _db.Follow.Remove(follower);
            }
        }
    }
}
