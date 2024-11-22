using PersonalPlayGround.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PersonalPlayGround.RecipeReviewData.Repository
{
    public class RecipeReviewRepository : IRecipeReviewRepository
    {
        private readonly ApplictionDatabase _database;
        public RecipeReviewRepository() { }
        public RecipeReviewRepository(ApplictionDatabase database)
        {
            _database = database;
        }

        public void AddRecipeReview(RecipeReview recipeReview)
        {
            _database.Entry(recipeReview).State = EntityState.Added;
            _database.SaveChanges();
        }

        public void UpdateRecipeReview(RecipeReview recipeReview)
        {
            _database.Entry(recipeReview).State = EntityState.Modified;
            _database.SaveChanges();
        }

        public RecipeReview GetRecipeReviewById(int recipeReviewId)
        {
            return _database.RecipeReviews.Find(recipeReviewId);
        }

        public List<RecipeReview> GetRecipeReviewsByRecipeId(int recipeId)
        {
            return _database.RecipeReviews
                            .AsNoTracking()
                            .Where(r => r.RecipeId == recipeId)
                            .ToList();
        }

        public List<RecipeReview> GetAllRecipeReviews()
        {
            return _database.RecipeReviews
                            .AsNoTracking()
                            .ToList();
        }
    }
}