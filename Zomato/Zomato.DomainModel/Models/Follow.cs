using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class Follow
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FollowerId { get; set; }
    }
}
