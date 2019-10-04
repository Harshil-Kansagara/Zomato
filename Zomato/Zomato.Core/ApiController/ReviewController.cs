using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public class ReviewController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public ReviewController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("restaurant/{restaurantId}/review")]
        public ReviewCollection GetReview (int restaurantId)
        {
            /*
             Change GetLikeCOuntbyReviewId to GetLikeByReviewId and add count method at last
             Change GetCommentCOuntbyReviewId to GetCommentByReviewId and add count method at last
             */

            int likeCount = 0;
            int commentCount = 0;
            string userName = null;

            ReviewCollection reviewCollection = new ReviewCollection();
            reviewCollection.Review = _unitOfWork.ReviewRepository.GetReviewByRestaurantId(restaurantId);
           
            for(int i=0;i<reviewCollection.Review.Count;i++)
            {
                likeCount = _unitOfWork.LikeRepository.GetLikeCountByReviewId(reviewCollection.Review[i].ReviewId);
                commentCount = _unitOfWork.CommentRepository.GetCommentCountByReviewId(reviewCollection.Review[i].ReviewId);
                userName = _unitOfWork.UserRepository.GetUsernameByUserId(reviewCollection.Review[i].UserId);

                reviewCollection.LikeCommentCountCollection.Add(new ReviewDataCollection( reviewCollection.Review[i].ReviewId, likeCount, commentCount, userName));
            }

            return reviewCollection;
        }

        [HttpGet]
        [Route("user/{userId}/review")]
        public UserReviewCollection GetReviewofUser(string userId)
        {
            UserReviewCollection userReviewCollection = new UserReviewCollection();
            userReviewCollection.Reviews = _unitOfWork.ReviewRepository.GetReviewByUserId(userId);
            String restaurantName = null;

            for(int i=0; i<userReviewCollection.Reviews.Count;i++)
            {
                restaurantName = _unitOfWork.RestaurantRepository.GetRestaurantNameById(userReviewCollection.Reviews[i].RestaurantId);
                userReviewCollection.UserReviewDataCollection.Add(new UserReviewDataCollection(userReviewCollection.Reviews[i].RestaurantId, restaurantName));
            }
            return userReviewCollection;
        }

        [HttpPost]
        [Route("restaurant/{restaurantId}/review")]
        public IActionResult AddReview(Review newReview)
        {
            Review review = _unitOfWork.ReviewRepository.AddReview(newReview);
            _unitOfWork.commit();
            return Ok();
        }
    }
}
