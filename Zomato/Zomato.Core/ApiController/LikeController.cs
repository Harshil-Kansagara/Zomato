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
    public class LikeController : ControllerBase
    {
        private UnitOfWork _unitOfWork;

        public LikeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("review/{reviewId}/like")]
        public LikeCollection GetLikeCollection(int reviewId)
        {
            string userName = null;
            LikeCollection likeCollection = new LikeCollection();
            likeCollection.Like = _unitOfWork.LikeRepository.GetLikeByReviewId(reviewId);

            for(int i = 0; i < likeCollection.Like.Count; i++)
            {
                userName = _unitOfWork.UserRepository.GetUsernameByUserId(likeCollection.Like[i].UserId);
                likeCollection.LikeDataCollection.Add(new LikeDataCollection(likeCollection.Like[i].LikeId, userName));
            }

            return likeCollection;
        }

        [HttpPost]
        [Route("review/{reviewId}/like")]
        public IActionResult AddLike (Like newLike)
        {
            Like like = _unitOfWork.LikeRepository.AddLike(newLike);
            _unitOfWork.commit();
            return Ok();
        }
    }
}
