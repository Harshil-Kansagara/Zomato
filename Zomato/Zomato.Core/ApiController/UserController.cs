using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;
using Zomato.Repository.UnitofWork;

namespace Zomato.Core.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UnitOfWork _unitOfWork;

        public UserController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("register")]
        public async Task<Object> AddUser(User newUser)
        {
            var user = new IdentityUser
            {
                UserName = newUser.UserName,
                Email = newUser.UserEmailAddress,
                PhoneNumber = newUser.UserMobileNumber
            };

            try
            {
                var result = await _unitOfWork.UserRepository.RegisterUser(user, newUser.UserPassword);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login (User user)
        {
            var result = await _unitOfWork.UserRepository.Login(user);
            return Ok();  
        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IdentityUser> GetUserDetail(string userId)
        {
            return await _unitOfWork.UserRepository.GetUserDetail(userId);
        }
    }
}
