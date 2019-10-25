using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class Follow
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser IdentityUser { get; set; }

        public string FollowerId { get; set; }
        [ForeignKey("FollowerId")]
        public IdentityUser User { get; set; }
    }
}
