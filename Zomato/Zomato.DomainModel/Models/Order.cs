using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int RestauratnId { get; set; }
        public string UserId { get; set; }
        public string UserLocation { get; set; }
        public string OrderDate { get; set; }
    }
}
