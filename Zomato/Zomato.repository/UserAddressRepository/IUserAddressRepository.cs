using System;
using System.Collections.Generic;
using System.Text;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.UserAddressRepository
{
    public interface IUserAddressRepository
    {
        List<UserAddress> GetAddressList(string userId);
        UserAddress AddAddress(UserAddress userAddress);
        void deleteAddress(int addressId);
    }
}
