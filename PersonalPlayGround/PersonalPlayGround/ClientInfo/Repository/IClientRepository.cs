using PersonalPlayGround.RecipeReviewData;
using System.Collections.Generic;

namespace PersonalPlayGround.ClientInfo.Repository
{
    public interface IClientRepository
    {
        List<Client> GetAllClients();
        Client GetClientById(string clientId);
        Client GetClientByUsername(string username);
        void AddClient(Client client);
        RecipeReview ClientReview(string clientId, int recipeId);
    }
}