using System.Collections.Generic;

namespace PersonalPlayGround.ClientInfo.Repository
{
    public interface IClientService
    {
        List<Client> GetAllClients();
        Client GetClientById(int clientId);
        bool AuthorizeClient(string username, string password);
        Client GetClientByUsername(string username);
        bool AddClient(Client client);
        bool ClientLeftReview(int clientId, int recepieId);
    }
}