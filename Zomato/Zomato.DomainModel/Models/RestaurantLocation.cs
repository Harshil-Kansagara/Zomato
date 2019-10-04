using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class RestaurantLocation
    {
        [Key]
        public int LocationId { get; set; }

        public int RestaurantId { get; set; }

        public string Location { get; set; }
    }
}
