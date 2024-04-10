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

        public void AddClient(Client client)
        {
            Client existingClient = GetClientByUsername(client.UserName);

            if (existingClient != null)
            {
                return;
            }

            _clientRepository.AddClient(client);
        }

        public bool AuthorizeClient(string username, string password)
        {
            return AspNetIdentityUser.AuthorizeAspNetUser(username, password);
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