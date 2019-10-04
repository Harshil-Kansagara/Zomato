using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewData { get; set; }
        public int rating { get; set; }
        public string UserId { get; set; }
        public int RestaurantId { get; set; }
    }
}
