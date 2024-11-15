using System.Collections.Generic;

namespace PersonalPlayGround.ClientInfo.Repository
{
    public interface IClientService
    {
        List<Client> GetAllClients();
        Client GetClientById(string clientId);
        bool AuthorizeClient(string username, string hashedPassword);
        Client GetClientByUsername(string username);
        void AddClient(Client client);
        void RemoveClient(Client client);
        bool ClientLeftReview(string clientId, int recipeId);
    }
}