using System.Collections.Generic;

namespace PersonalPlayGround.ClientInfo
{
    public interface IClientRepository
    {
        List<Client> GetAllClients();
        Client GetClientById(int clientId);
        Client GetClientByCredentials(string username, string password);
        Client GetClientByUsername(string username);
        bool AddClient(Client client);
    }
}