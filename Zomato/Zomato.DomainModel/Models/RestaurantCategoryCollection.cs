using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class RestaurantCategoryCollection
    {
        private Category category;

        public RestaurantCategoryCollection(int restaurantId, Category category)
        {
            RestaurantId = restaurantId;
            this.category = category;
        }

        public int RestaurantId { get; set; }
        public string CategoryName { get; set; }
    }
}
