using PersonalPlayGround.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PersonalPlayGround.ClientInfo
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplictionDatabase _database;
        public ClientRepository() { }
        public ClientRepository(ApplictionDatabase database)
        {
            _database = database;
        }

        public Client GetClientByCredentials(string username, string password)
        {
            return _database.Clients.Where(client => client.UserName == username && client.Password == password).FirstOrDefault();
        }

        public List<Client> GetAllClients()
        {
            return _database.Clients.ToList();
        }

        public Client GetClientById(int clientId)
        {
            return _database.Clients.Find(clientId);
        }

        public Client GetClientByUsername(string username)
        {
            return _database.Clients.Where(client => client.UserName.Equals(username)).FirstOrDefault();
        }

        public bool AddClient(Client client)
        {
            Client existingClient = GetClientByUsername(client.UserName);

            if(existingClient != null)
            {
                return false;
            }

            _database.Entry(client).State = EntityState.Added;
            _database.SaveChanges();

            return true;
        }
    }
}
