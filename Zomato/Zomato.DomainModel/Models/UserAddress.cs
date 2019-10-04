using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class UserAddress
    {
        [Key]
        public int AddressId { get; set; }

        public string Address { get; set; }
        
        public string UserId { get; set; }
    }
}
