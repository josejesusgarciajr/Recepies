﻿using PersonalPlayGround.Data;
using PersonalPlayGround.RecepieReviewData;
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

        public void AddClient(Client client)
        {
            _database.Entry(client).State = EntityState.Added;
            _database.SaveChanges();
        }

        public RecepieReview ClientReview(int clientId, int recepieId)
        {
            return _database.RecepieReviews
                    .Where
                    (
                        rr => rr.RecepieId == recepieId 
                        && rr.ClientId == clientId
                    ).FirstOrDefault();
        }
    }
}
