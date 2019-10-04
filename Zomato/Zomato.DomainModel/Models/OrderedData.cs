using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class OrderedData
    {
        public int RestaurantId { get; set; }
        public string UserId { get; set; }
        public string UserLocation { get; set; }
        public List<ItemDataCollection> ItemDataCollection { get; set; }
    }
}
