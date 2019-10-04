using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestaurantLocationRepository
{
    public interface IRestLocationRepository
    {
        List<RestaurantLocation> GetRestLocationById(int restaurantId);
        RestaurantLocation AddRestLocation(RestaurantLocation restaurantLocation);
    }
}
