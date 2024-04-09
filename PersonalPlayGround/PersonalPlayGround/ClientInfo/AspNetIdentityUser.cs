using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

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
    }
}