using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.UserAddressRepository
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private readonly ApplicationDbContext _db;

        public UserAddressRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<UserAddress> AddAddress(UserAddress userAddress)
        {
            await _db.UserAddress.AddAsync(userAddress);
            return userAddress;
        }

        public async Task deleteAddress(int addressId)
        {
            var address = await _db.UserAddress.FindAsync(addressId);
            if (address != null)
            {
                _db.UserAddress.Remove(address);
            }
        }

        public async Task EditAddress(UserAddress userAddress)
        {
            var address = await _db.UserAddress.Where(x => x.AddressId == userAddress.AddressId).ToListAsync();
            address.ForEach(
                    x => {
                   x.Address = userAddress.Address;
               }
             );
            
            
        }

        public async Task<List<UserAddress>> GetAddressList(string userId)
        {
            return await _db.UserAddress.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<string> GetAddressNameById(int addressId)
        {
            var address = await _db.UserAddress.FindAsync(addressId);
            return address.Address;
        }
    }
}
