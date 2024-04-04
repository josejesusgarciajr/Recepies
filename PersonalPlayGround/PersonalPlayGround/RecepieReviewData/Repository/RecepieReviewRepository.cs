using PersonalPlayGround.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PersonalPlayGround.RecepieReviewData.Repository
{
    public class RecepieReviewRepository : IRecepieReviewRepository
    {
        private readonly ApplictionDatabase _database;
        public RecepieReviewRepository() { }
        public RecepieReviewRepository(ApplictionDatabase database)
        {
            _database = database;
        }

        public void AddRecepieReview(RecepieReview recepieReview)
        {
            _database.Entry(recepieReview).State = EntityState.Added;
            _database.SaveChanges();
        }

        public List<RecepieReview> GetAllRecepieReviews()
        {
            return _database.RecepieReviews.ToList();
        }

        public List<RecepieReview> GetRecepieReviewsByRecepieId(int recepieId)
        {
            return _database.RecepieReviews.Where(r => r.RecepieId == recepieId).ToList();
        }
    }
}