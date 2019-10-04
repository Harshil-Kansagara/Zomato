using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class RestCategory
    {
        [Key]
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public int CategoryId { get; set; }
    }
}
