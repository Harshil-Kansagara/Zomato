using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class Menu
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ItemPrice { get; set; } 
        public int RestaurantId { get; set; }
    }
}
