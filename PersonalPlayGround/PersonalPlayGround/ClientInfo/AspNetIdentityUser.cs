using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PersonalPlayGround.ClientInfo
{
    public static class AspNetIdentityUser
    {
        public static Tuple<IdentityResult, Client> CreateClientUser(string name, string username, string password)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            IdentityUser identityUser = new IdentityUser { UserName = username };
            IdentityResult result = manager.Create(identityUser, password);

            Client client = new Client
            {
                Id = identityUser.Id,
                Name = name,
                UserName = username,
                PasswordHash = identityUser.PasswordHash
            };

            return Tuple.Create(result, client);
        }

        public static List<IdentityUser> GetAllClientUsers()
        {
            var userStore = new UserStore<IdentityUser>();

            return userStore.Users
                            .AsNoTracking()
                            .ToList();
        }

        public static void DeleteAspNetIdentityUser(string username)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            IdentityUser existingUser = manager.FindByName(username);

            if(existingUser != null)
            {
                manager.DeleteAsync(existingUser);
            }
        }

        public static bool AuthorizeAspNetUser(string username, string password)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // Find the user by username
            var user = userManager.FindByName(username);

            // Check if the user exists and the provided password is correct
            if (user != null && userManager.CheckPassword(user, password))
            {
                // User is authenticated, you can proceed with login
                return true;
            }
            else
            {
                // Invalid username or password
                return false;
            }
        }
    }
}