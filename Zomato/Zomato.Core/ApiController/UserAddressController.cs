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
    public class UserAddressController : ControllerBase
    {
        private UnitOfWork _unitOfWork;

        public UserAddressController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("user/{userId}/address")]
        public List<UserAddress> GetAddressList(string userId)
        {
            return _unitOfWork.UserAddressRepository.GetAddressList(userId);
        }

        [HttpPost]
        [Route("user/{userId}/address")]
        public IActionResult AddAddress (UserAddress newUserAddress)
        {
            UserAddress userAddress = _unitOfWork.UserAddressRepository.AddAddress(newUserAddress);
            _unitOfWork.commit();
            return Ok();
        }

        [HttpDelete]
        [Route("address/{addressId}")]
        public void DeleteAddress(int addressId)
        {
            try
            {
                _unitOfWork.UserAddressRepository.deleteAddress(addressId);
                _unitOfWork.commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
