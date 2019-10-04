using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.CommentRepository
{
    public interface ICommentRepository
    {
        int GetCommentCountByReviewId(int reviewId);
        List<Comment> GetCommentByReviewId(int reviewId);
        Comment AddComment(Comment comment);
    }
}
