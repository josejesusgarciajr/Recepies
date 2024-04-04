using PersonalPlayGround.RecepieReviewData;
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
            Client client = _clientRepository.GetClientByCredentials(username, password);
            
            if(client is null)
            {
                return false;
            }

            if(client.UserName.Equals(username) && client.Password.Equals(password)) 
            {
                return true;
            }

            return false;
        }

        public bool ClientLeftReview(int clientId, int recepieId)
        {
            RecepieReview recepieReview = _clientRepository.ClientReview(clientId, recepieId);

            if(recepieReview == null)
            {
                return false;
            }

            return true;
        }

        public List<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        public Client GetClientById(int clientId)
        {
            return _clientRepository.GetClientById(clientId);
        }

        public Client GetClientByUsername(string username)
        {
            return _clientRepository.GetClientByUsername(username);
        }
    }
}