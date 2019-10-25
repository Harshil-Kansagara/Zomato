using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;
using Zomato.Repository.UnitofWork;

namespace Zomato.Core.Controllers
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
        [Route("{restaurantName}/review")]
        public async Task<List<ReviewCollection>> GetReview (string restaurantName)
        {
            restaurantName = restaurantName.Replace('-', ' ');
            var restaurantId = await _unitOfWork.RestaurantRepository.GetRestaurantIdByRestaurantName(restaurantName);

            List<ReviewCollection> reviewCollection = new List<ReviewCollection>();
            var reviewList = await _unitOfWork.ReviewRepository.GetReviewByRestaurantId(restaurantId);
           
            foreach(var review in reviewList)
            {
                var model = new ReviewCollection();
                model.Review = review;
                model.UserName = _unitOfWork.UserRepository.GetUsernameByUserId(review.UserId).Result.UserName;
                model.LikeCount = _unitOfWork.LikeRepository.GetLikeByReviewId(review.ReviewId).Result.Count;
                model.CommentCount = _unitOfWork.CommentRepository.GetCommentByReviewId(review.ReviewId).Result.Count;

                reviewCollection.Add(model);
            }

            return reviewCollection;
        }

        [HttpGet]
        [Route("user/{userId}/review")]
        public async Task<UserReviewCollection> GetReviewofUser(string userId)
        {
            UserReviewCollection userReviewCollection = new UserReviewCollection();
            userReviewCollection.Reviews = await _unitOfWork.ReviewRepository.GetReviewByUserId(userId);
            String restaurantName = null;

            for(int i=0; i<userReviewCollection.Reviews.Count;i++)
            {
                restaurantName = await _unitOfWork.RestaurantRepository.GetRestaurantNameById(userReviewCollection.Reviews[i].RestaurantId);
                userReviewCollection.UserReviewDataCollection.Add(new UserReviewDataCollection(userReviewCollection.Reviews[i].RestaurantId, restaurantName));
            }
            return userReviewCollection;
        }

        [HttpPost]
        [Route("{restaurantName}/review")]
        public async Task<IActionResult> AddReview(string restaurantName, Review newReview)
        {
            if (ModelState.IsValid) { 
                restaurantName = restaurantName.Replace('-', ' ');
                var restaurantId = await _unitOfWork.RestaurantRepository.GetRestaurantIdByRestaurantName(restaurantName);
                newReview.RestaurantId = restaurantId;
                Review review = await _unitOfWork.ReviewRepository.AddReview(newReview);
                _unitOfWork.commit();
                return Ok();
            }
            return BadRequest();
        }
    }
}
