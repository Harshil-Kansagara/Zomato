using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestCategoryRepository
{
    public class RestCategoryRepository : IRestCategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public RestCategoryRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<RestCategory> AddRestCategory(RestCategory restCategory)
        {
            await _db.RestCategory.AddAsync(restCategory);
            return restCategory;
        }

        public async Task<List<RestCategory>> GetRestaurantIdByCategoryId(int categoryId)
        {
            return await _db.RestCategory.Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        public async Task<List<RestCategory>> GetRestCategoryByRestaurantId(int restaurantId)
        {
            return await _db.RestCategory.Where(x => x.RestaurantId == restaurantId).ToListAsync();
        }
    }
}
