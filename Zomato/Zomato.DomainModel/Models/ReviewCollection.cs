using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class ReviewCollection
    {
        public List<Review> Review { get; set; }
        public List<ReviewDataCollection> LikeCommentCountCollection { get; set; }
    }
}
