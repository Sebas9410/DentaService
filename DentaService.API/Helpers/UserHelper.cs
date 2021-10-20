using DentaService.API.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentaService.API.Helpers
{

    public class UserHelper : IUserHelper
    {

        public UserHelper(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {

        }

        public Task<IdentityResult> AddUserAsync(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task AddUserToRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task CheckRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
