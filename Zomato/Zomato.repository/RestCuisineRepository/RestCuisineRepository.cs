using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestCuisineRepository
{
    public class RestCuisineRepository : IRestCuisineRepository
    {
        public RestCuisine AddRestCuisine(RestCuisine restCuisine)
        {
            throw new NotImplementedException();
        }

        public List<RestCuisine> GetRestCuisinesByRestaurantId(int restaurantId)
        {
            throw new NotImplementedException();
        }
    }
}
