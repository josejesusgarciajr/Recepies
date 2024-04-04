using PersonalPlayGround.RecepieReviewData;
using System.Collections.Generic;

namespace PersonalPlayGround.ClientInfo.Repository
{
    public interface IClientRepository
    {
        List<Client> GetAllClients();
        Client GetClientById(int clientId);
        Client GetClientByCredentials(string username, string password);
        Client GetClientByUsername(string username);
        void AddClient(Client client);
        RecepieReview ClientReview(int clientId, int recepieId);
    }
}