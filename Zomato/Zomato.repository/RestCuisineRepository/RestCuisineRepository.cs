using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestCuisineRepository
{
    public class RestCuisineRepository : IRestCuisineRepository
    {
        private readonly ApplicationDbContext _db;

        public RestCuisineRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<RestCuisine> AddRestCuisine(RestCuisine restCuisine)
        {
            await _db.RestCuisine.AddAsync(restCuisine);
            return restCuisine;
        }

        public async Task<List<RestCuisine>> GetRestaurantIdByCuisineId(int cuisineId)
        {
            return await _db.RestCuisine.Where(x => x.CuisineId == cuisineId).ToListAsync();
        }

        public async Task<List<RestCuisine>> GetRestCuisinesByRestaurantId(int restaurantId)
        {
            return await _db.RestCuisine.Where(x => x.RestaurantId == restaurantId).ToListAsync();
        }
    }
}
