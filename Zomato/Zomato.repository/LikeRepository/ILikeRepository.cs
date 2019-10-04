using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.LikeRepository
{
    public interface ILikeRepository
    {
        int GetLikeCountByReviewId(int reviewId);
        List<Like> GetLikeByReviewId(int reviewId);
        Like AddLike(Like like);
    }
}
