using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;
using Zomato.Repository.DataRepository;

namespace Zomato.Repository.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        private IDataRepository _dataRepository;

        public ReviewRepository(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task<Review> AddReview(Review newReview)
        {
            await _dataRepository.AddAsync(newReview);
            return newReview;
        }

        public async Task DeleteReview(int reviewId)
        {
            var review = await _dataRepository.Find<Review>(reviewId);
            if (review != null)
            {
                _dataRepository.Remove(review);
            }
        }

        public async Task<List<Review>> GetReviewByRestaurantId(int restaurantId)
        {
            return await _dataRepository.Where<Review>(x => x.RestaurantId == restaurantId).ToListAsync();
        }

        public async Task<List<Review>> GetReviewByUserId(string userId)
        {
            return await _dataRepository.Where<Review>(x => x.UserId == userId).ToListAsync();
        }
    }
}
