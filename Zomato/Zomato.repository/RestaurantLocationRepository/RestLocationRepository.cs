using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestaurantLocationRepository
{
    public class RestLocationRepository : IRestLocationRepository
    {
        private readonly ApplicationDbContext _db;

        public RestLocationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<RestaurantLocation> AddRestLocation(RestaurantLocation restaurantLocation)
        {
            await _db.RestaurantLocation.AddAsync(restaurantLocation);
            return restaurantLocation;
        }

        public async Task<List<RestaurantLocation>> GetRestLocationById(int restaurantId)
        {
            return await _db.RestaurantLocation.Where(x => x.RestaurantId == restaurantId).ToListAsync();
        }
    }
}
