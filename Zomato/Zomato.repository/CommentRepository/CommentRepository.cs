using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.CommentRepository
{
    public class CommentRepository : ICommentRepository
    {
        public Comment AddComment(Comment comment)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetCommentByReviewId(int reviewId)
        {
            throw new NotImplementedException();
        }

        public int GetCommentCountByReviewId(int reviewId)
        {
            throw new NotImplementedException();
        }
    }
}
