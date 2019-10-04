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
    public class FollowController : ControllerBase
    {
        private UnitOfWork _unitOfWork;

        public FollowController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        [Route("user/{userId}/follower")]
        public FollowCollection GetFollowers(string userId)
        {
            FollowCollection followCollection = new FollowCollection();
            List<Follow> followers = _unitOfWork.FollowRepository.GetFollowersByUserId(userId);
            String userName = null;
            for (int i=0;i<followers.Count;i++)
            {
                userName = _unitOfWork.UserRepository.GetUsernameByUserId(followers[i].FollowerId);
                followCollection.UserName.Add(userName);
            }

            return followCollection;
        }

        [HttpGet]
        [Route("user/{userId}/following")]
        public FollowCollection GetFollowing(string userId)
        {
            FollowCollection followCollection = new FollowCollection();
            List<Follow> following = _unitOfWork.FollowRepository.GetFollowingFromFollowerId(userId);
            String userName = null;
            for(int i = 0; i < following.Count; i++)
            {
                userName = _unitOfWork.UserRepository.GetUsernameByUserId(following[i].UserId);
                followCollection.UserName.Add(userName);
            }

            return followCollection;
        }

        [HttpPost]
        [Route("user/{userId}/follower")]
        public IActionResult AddFollowers(Follow newFollow)
        {
            Follow follow = _unitOfWork.FollowRepository.AddFollower(newFollow);
            _unitOfWork.commit();
            return Ok();
        }
    }
}
