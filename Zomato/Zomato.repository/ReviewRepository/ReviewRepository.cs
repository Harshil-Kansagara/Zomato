using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        public Review AddReview(Review newReview)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetReviewByRestaurantId(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public List<Review> GetReviewByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
