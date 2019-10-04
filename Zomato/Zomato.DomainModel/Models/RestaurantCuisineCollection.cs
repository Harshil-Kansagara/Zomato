using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class RestaurantCuisineCollection
    {
        private Cuisine cuisine;

        public RestaurantCuisineCollection(int restaurantId, Cuisine cuisine)
        {
            RestaurantId = restaurantId;
            this.cuisine = cuisine;
        }

        public int RestaurantId { get; set; }
        public string CuisineName { get; set; }
    }
}
