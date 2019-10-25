using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Zomato.DomainModel.Data;
using Zomato.DomainModel.Models;

namespace Zomato.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserRepository(ApplicationDbContext db, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) //RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserToRole(IdentityUser user, string roleName)
        {
           return await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityUser> FindByEmail(string email)
        {
           return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityUser> GetUserDetail(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUser> GetUsernameByUserId(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<string> GetUserRole(User user)
        {
            var result = await _userManager.GetRolesAsync(await FindByEmail(user.UserEmailAddress));
            return result[0];
        }

        public async Task<SignInResult> Login(User userData)
        {
            var user = await FindByEmail(userData.UserEmailAddress);
            return await _signInManager.PasswordSignInAsync(user.UserName, userData.UserPassword, false, false);
        }

        public async Task<IdentityResult> RegisterUser(IdentityUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
    }
}
