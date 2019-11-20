using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestaurantRepository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ApplicationDbContext _db;

        public RestaurantRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            await _db.Restaurant.AddAsync(restaurant);
            return restaurant;
        }

        public async Task deleteRestaurant(int restaurantId)
        {
            var restaurant = await _db.Restaurant.FindAsync(restaurantId);
            if(restaurant != null)
            {
                _db.Restaurant.Remove(restaurant);
            }
        }

        public async Task<Restaurant> GetRestaurantById(int restaurantId)
        {
            return await _db.Restaurant.Where(x => x.RestaurantId == restaurantId).FirstAsync();
        }

        public async Task<string> GetRestaurantNameById(int restaurantId)
        {
            var restaurant = await _db.Restaurant.FindAsync(restaurantId);
            return restaurant.RestaurantName;
        }

        public async Task<List<Restaurant>> ListRestaurant()
        {
            return await _db.Restaurant.ToListAsync();
        }

        public async Task<int> GetRestaurantIdByRestaurantName(string restaurantName)
        {
            var restaurant= await _db.Restaurant.Where(x => x.RestaurantName == restaurantName).FirstOrDefaultAsync();
            if (restaurant != null) { 
                return restaurant.RestaurantId;
            }
            return 0;
        }
    }
}
