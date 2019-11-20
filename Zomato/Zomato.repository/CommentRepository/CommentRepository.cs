using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.CommentRepository
{
    public class CommentRepository : ICommentRepository
    {
        private ApplicationDbContext _db;

        public CommentRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Comment> AddComment(Comment comment)
        {
            await _db.Comment.AddAsync(comment);
            return comment;
        }

        public async Task DeleteComment(int reviewId)
        {
            var commentList = await _db.Comment.Where(x => x.ReviewId == reviewId).ToListAsync();
            foreach (var each in commentList)
            {
                _db.Comment.Remove(each);
            }
        }

        public async Task<List<Comment>> GetCommentByReviewId(int reviewId)
        {
            return await _db.Comment.Where(x => x.ReviewId == reviewId).ToListAsync();
        }
    }
}
