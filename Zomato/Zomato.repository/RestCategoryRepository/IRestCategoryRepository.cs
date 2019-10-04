using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.RestCategoryRepository
{
    public interface IRestCategoryRepository
    {
        List<RestCategory> GetRestCategoryByRestaurantId(int restaurantId);
        RestCategory AddRestCategory(RestCategory restCategory);
    }
}
