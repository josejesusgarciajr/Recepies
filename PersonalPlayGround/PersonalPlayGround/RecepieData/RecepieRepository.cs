using PersonalPlayGround.Data;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace PersonalPlayGround.RecepieData
{
    public class RecepieRepository : IRecepieRepository
    {
        private readonly ApplictionDatabase _database;
        public RecepieRepository(ApplictionDatabase database)
        {
            _database = database;
        }

        public List<Recepie> GetRecepies()
        {
            return _database.Recepies.ToList();
        }

        public List<Recepie> GetActiveRecepies()
        {
            return _database.Recepies.Where(r => r.Active).ToList();
        }

        public List<Recepie> GetRecepieBySearch(string search)
        {
            return _database.Recepies.Where(r => r.Name.Contains(search) ).ToList();
        }

        public Recepie GetRecepieById(int recepieId)
        {
            return _database.Recepies.Find(recepieId);
        }

        public Recepie UpdateRecepie(Recepie recepie)
        {
            _database.Entry(recepie).State = EntityState.Modified;
            _database.SaveChanges();

            return _database.Recepies.Find(recepie.Id);
        }

        public int AddRecepie(Recepie recepie)
        {
            _database.Entry(recepie).State = EntityState.Added;
            _database.SaveChanges();

            return recepie.Id;
        }

        public void DeleteRecepie(int recepieId)
        {
            Recepie recepie = _database.Recepies.Find(recepieId);
            _database.Entry(recepie).State = EntityState.Deleted;
            _database.SaveChanges();
        }
    }
}