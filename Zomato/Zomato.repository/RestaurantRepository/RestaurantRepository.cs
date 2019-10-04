using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestaurantRepository
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public void deleteRestaurant(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetRestaurantById(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public string GetRestaurantNameById(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> ListRestaurant()
        {
            throw new NotImplementedException();
        }
    }
}
