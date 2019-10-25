using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class ReviewCollection
    {
        public Review Review { get; set; }
        public string UserName { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
    }
}
