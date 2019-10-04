using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string CommentData { get; set; }
        public string UserId { get; set; }
        public int ReviewId { get; set; }
    }
}
