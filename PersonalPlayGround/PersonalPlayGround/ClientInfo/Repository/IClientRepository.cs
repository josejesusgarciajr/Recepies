using PersonalPlayGround.RecipeReviewData;
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
        RecipeReview ClientReview(int clientId, int recipeId);
    }
}