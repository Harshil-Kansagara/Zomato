using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestCuisineRepository
{
    public interface IRestCuisineRepository
    {
        List<RestCuisine> GetRestCuisinesByRestaurantId(int restaurantId);
        RestCuisine AddRestCuisine(RestCuisine restCuisine);
    }
}
