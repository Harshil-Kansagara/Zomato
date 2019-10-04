using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestaurantRepository
{
    public interface IRestaurantRepository
    {
        List<Restaurant> ListRestaurant();
        Restaurant AddRestaurant(Restaurant restaurant);
        Restaurant GetRestaurantById(int restaurantId);
        string GetRestaurantNameById(int restaurantId);
        void deleteRestaurant(int restaurantId);
    }
}
