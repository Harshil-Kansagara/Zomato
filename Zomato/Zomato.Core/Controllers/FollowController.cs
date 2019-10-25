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
    public class FollowController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public FollowController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpGet]
        [Route("user/{userId}/follower")]
        public async Task<FollowCollection> GetFollowers(string userId)
        {
            FollowCollection followCollection = new FollowCollection();
            List<Follow> followers = await _unitOfWork.FollowRepository.GetFollowersByUserId(userId);
            String userName = null;
            for (int i=0;i<followers.Count;i++)
            {
                userName = _unitOfWork.UserRepository.GetUsernameByUserId(followers[i].FollowerId).Result.UserName;
                followCollection.UserName.Add(userName);
            }

            return followCollection;
        }

        [HttpGet]
        [Route("user/{userId}/following")]
        public async Task<FollowCollection> GetFollowing(string userId)
        {
            FollowCollection followCollection = new FollowCollection();
            List<Follow> following = await _unitOfWork.FollowRepository.GetFollowingFromFollowerId(userId);
            String userName = null;
            for(int i = 0; i < following.Count; i++)
            {
                userName = _unitOfWork.UserRepository.GetUsernameByUserId(following[i].UserId).Result.UserName;
                followCollection.UserName.Add(userName);
            }

            return followCollection;
        }

        [HttpPost]
        [Route("user/{userId}/follower")]
        public async Task<IActionResult> AddFollowers(Follow newFollow)
        {
            Follow follow = await _unitOfWork.FollowRepository.AddFollower(newFollow);
            _unitOfWork.commit();
            return Ok();
        }
    }
}
