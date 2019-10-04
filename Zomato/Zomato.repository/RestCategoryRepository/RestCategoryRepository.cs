using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestCategoryRepository
{
    public class RestCategoryRepository : IRestCategoryRepository
    {
        public RestCategory AddRestCategory(RestCategory restCategory)
        {
            throw new NotImplementedException();
        }

        public List<RestCategory> GetRestCategoryByRestaurantId(int restaurantId)
        {
            throw new NotImplementedException();
        }
    }
}
