using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {
        private ApplicationDbContext _db;

        public ReviewRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Review> AddReview(Review newReview)
        {
            await _db.Review.AddAsync(newReview);
            return newReview;
        }

        public async Task<List<Review>> GetReviewByRestaurantId(int restaurantId)
        {
            return await _db.Review.Where(x => x.RestaurantId == restaurantId).ToListAsync();
        }

        public async Task<List<Review>> GetReviewByUserId(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
