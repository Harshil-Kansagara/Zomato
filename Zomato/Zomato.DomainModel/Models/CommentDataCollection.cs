using System;
using System.Collections.Generic;
using System.Text;

namespace Zomato.DomainModel.Models
{
    public class CommentDataCollection
    {
        public int CommentId { get; set; }
        public string UserName { get; set; }

        public CommentDataCollection(int commentId, string userName)
        {
            CommentId = commentId;
            UserName = userName;
        }
    }
}
