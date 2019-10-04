using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.LikeRepository
{
    public class LikeRepository : ILikeRepository
    {
        public Like AddLike(Like like)
        {
            throw new NotImplementedException();
        }

        public List<Like> GetLikeByReviewId(int reviewId)
        {
            throw new NotImplementedException();
        }

        public int GetLikeCountByReviewId(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
