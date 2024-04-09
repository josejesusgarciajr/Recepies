using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PersonalPlayGround.RecipeReviewData;
using System.Collections.Generic;

namespace PersonalPlayGround.ClientInfo.Repository
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService() { }
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public bool AddClient(Client client)
        {
            Client existingClient = GetClientByUsername(client.UserName);

            if (existingClient != null)
            {
                return false;
            }

            _clientRepository.AddClient(client);
            return true;
        }

        public bool AuthorizeClient(string username, string password)
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

        public bool ClientLeftReview(string clientId, int recipeId)
        {
            RecipeReview recipeReview = _clientRepository.ClientReview(clientId, recipeId);

            if(recipeReview == null)
            {
                return false;
            }

            return true;
        }

        public List<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        public Client GetClientById(string clientId)
        {
            return _clientRepository.GetClientById(clientId);
        }

        public Client GetClientByUsername(string username)
        {
            return _clientRepository.GetClientByUsername(username);
        }
    }
}