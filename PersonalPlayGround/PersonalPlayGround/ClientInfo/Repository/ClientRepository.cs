using PersonalPlayGround.Data;
using PersonalPlayGround.RecipeReviewData;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PersonalPlayGround.ClientInfo.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplictionDatabase _database;
        public ClientRepository() { }
        public ClientRepository(ApplictionDatabase database)
        {
            _database = database;
        }

        public List<Client> GetAllClients()
        {
            return _database.Clients.ToList();
        }

        public Client GetClientById(string clientId)
        {
            return _database.Clients.Find(clientId);
        }

        public Client GetClientByUsername(string username)
        {
            return _database.Clients.Where(client => client.UserName.Equals(username)).FirstOrDefault();
        }

        public void AddClient(Client client)
        {
            _database.Entry(client).State = EntityState.Added;
            _database.SaveChanges();
        }

        public RecipeReview ClientReview(string clientId, int recipeId)
        {
            return _database.RecipeReviews
                    .Where
                    (
                        rr => rr.RecipeId == recipeId 
                        && rr.ClientId == clientId
                    ).FirstOrDefault();
        }
    }
}
