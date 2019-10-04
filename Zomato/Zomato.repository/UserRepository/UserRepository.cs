using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        public Task<IdentityUser> GetUserDetail(string userId)
        {
            throw new NotImplementedException();
        }

        public string GetUsernameByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<SignInResult> Login(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> RegisterUser(IdentityUser user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
