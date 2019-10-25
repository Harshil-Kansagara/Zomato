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
            throw new NotImplementedException();
        }

        public async Task<List<UserAddress>> GetAddressList(string userId)
        {
            return await _db.UserAddress.Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
