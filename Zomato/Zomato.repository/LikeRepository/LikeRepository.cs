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
            await _db.Like.AddAsync(like);
            return like;
        }

        public async Task DeleteLike(int likeId)
        {
            var like = await _db.Like.FindAsync(likeId);
            if(like != null)
            {
                _db.Like.Remove(like);
            }
        }

        public async Task DeleteLikeByReview(int reviewId)
        {
            var like = await _db.Like.Where(x => x.ReviewId == reviewId).ToListAsync();
            foreach (var each in like)
            {
                _db.Like.Remove(each);
            }
        }

        public async Task<List<Like>> GetLikeByReviewId(int reviewId)
        {
            return await _db.Like.Where(x => x.ReviewId == reviewId).ToListAsync();
        }
    }
}
