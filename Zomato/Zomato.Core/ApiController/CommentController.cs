using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;
using Zomato.Repository.UnitofWork;

namespace Zomato.Core.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private UnitOfWork _unitOfWork;

        public CommentController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("review/{reviewId}/comment")]
        public CommentCollection GetComment(int reviewId)
        {
            string userName = null;

            CommentCollection commentCollection = new CommentCollection();
            commentCollection.Comment = _unitOfWork.CommentRepository.GetCommentByReviewId(reviewId);

            for(int i = 0; i < commentCollection.Comment.Count; i++)
            {
                userName = _unitOfWork.UserRepository.GetUsernameByUserId(commentCollection.Comment[i].UserId);
                commentCollection.CommentDataCollection.Add(new CommentDataCollection(commentCollection.Comment[i].CommentId, userName));
            }

            return commentCollection;
        }

        [HttpPost]
        [Route("review/{reviewId}/comment")]
        public IActionResult AddComment(Comment comment)
        {
            _unitOfWork.CommentRepository.AddComment(comment);
            _unitOfWork.commit();
            return Ok();
        }

    }
}
