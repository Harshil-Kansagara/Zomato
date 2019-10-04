using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class CommentCollection
    {
        public List<Comment> Comment { get; set; }
        public List<CommentDataCollection> CommentDataCollection { get; set; }
    }
}
