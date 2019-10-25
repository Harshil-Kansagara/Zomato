using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.LikeRepository
{
    public class LikeRepository : ILikeRepository
    {
        private ApplicationDbContext _db;

        public LikeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Like> AddLike(Like like)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Like>> GetLikeByReviewId(int reviewId)
        {
            return await _db.Like.Where(x => x.ReviewId == reviewId).ToListAsync();
        }
    }
}
