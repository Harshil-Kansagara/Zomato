using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.UserAddressRepository
{
    public class UserAddressRepository : IUserAddressRepository
    {
        public UserAddress AddAddress(UserAddress userAddress)
        {
            throw new NotImplementedException();
        }

        public void deleteAddress(int addressId)
        {
            throw new NotImplementedException();
        }

        public List<UserAddress> GetAddressList(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
