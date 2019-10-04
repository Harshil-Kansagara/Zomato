using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        public string UserId { get; set; }
        public int ReviewId { get; set; }
    }
}
