using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class RestaurantCollection
    {
        public List<Restaurant> Restaurant { get; set; }
        public List<RestaurantLocation> RestaurantLocation { get; set; }
        public List<RestaurantCuisineCollection> CuisineCollection { get; set; }
        public List<RestaurantCategoryCollection> CategoryCollection { get; set; }
    }
}
