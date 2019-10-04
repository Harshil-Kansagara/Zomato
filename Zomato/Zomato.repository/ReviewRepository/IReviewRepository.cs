using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.ReviewRepository
{
    public interface IReviewRepository
    {
        List<Review> GetReviewByRestaurantId(int restaurantId);
        List<Review> GetReviewByUserId(string userId);
        Review AddReview(Review newReview);
    }
}
