using PersonalPlayGround.Data;
using PersonalPlayGround.RecipeData.Repository;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace PersonalPlayGround.RecipeData
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplictionDatabase _database;
        public RecipeRepository(ApplictionDatabase database)
        {
            _database = database;
        }

        public List<Recipe> GetRecipes()
        {
            return _database.Recipes
                            .AsNoTracking()
                            .ToList();
        }

        public List<Recipe> GetActiveRecipes()
        {
            return _database.Recipes
                            .AsNoTracking()
                            .Where(r => r.Active)
                            .ToList();
        }

        public List<Recipe> GetRecipeBySearch(string search)
        {
            return _database.Recipes
                            .AsNoTracking()
                            .Where(r => r.Name.Contains(search))
                            .ToList();
        }

        public Recipe GetRecipeById(int recipeId)
        {
            return _database.Recipes.Find(recipeId);
        }

        public Recipe GetRecipeWithRelatedDataByRecipeId(int recipeId)
        {
            return _database.Recipes.AsNoTracking()
                                    .Include(r => r.Ratings.Select(rr => rr.Client))
                                    .FirstOrDefault(r => r.Id == recipeId);
        }

        public Recipe UpdateRecipe(Recipe recipe)
        {
            _database.Entry(recipe).State = EntityState.Modified;
            _database.SaveChanges();

            return recipe;
        }

        public int AddRecipe(Recipe recipe)
        {
            _database.Entry(recipe).State = EntityState.Added;
            _database.SaveChanges();

            return recipe.Id;
        }

        public void DeleteRecipe(int recipeId)
        {
            Recipe recipe = GetRecipeById(recipeId);
            _database.Entry(recipe).State = EntityState.Deleted;
            _database.SaveChanges();
        }
    }
}