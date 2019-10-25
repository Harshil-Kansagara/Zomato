using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.UserAddressRepository
{
    public interface IUserAddressRepository
    {
        Task<List<UserAddress>> GetAddressList(string userId);
        Task<UserAddress> AddAddress(UserAddress userAddress);
        Task deleteAddress(int addressId);
    }
}
