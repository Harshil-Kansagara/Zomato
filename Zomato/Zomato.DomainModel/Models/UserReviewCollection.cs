using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class UserReviewCollection
    {
        public List<Review> Reviews { get; set; }
        public List<UserReviewDataCollection> UserReviewDataCollection { get; set; }
    }
}
