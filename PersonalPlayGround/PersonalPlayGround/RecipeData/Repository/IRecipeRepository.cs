using System.Collections.Generic;

namespace PersonalPlayGround.RecipeData.Repository
{
    public interface IRecipeRepository
    {
        List<Recipe> GetRecipes();
        List<Recipe> GetActiveRecipes();
        List<Recipe> GetRecipeBySearch(string search);
        Recipe GetRecipeById(int recipeId);
        Recipe UpdateRecipe(Recipe recipe);
        int AddRecipe(Recipe recipe);
        void DeleteRecipe(int recipeId);
    }
}
