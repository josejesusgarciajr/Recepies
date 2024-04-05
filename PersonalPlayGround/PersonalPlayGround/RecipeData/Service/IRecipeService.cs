using System.Collections.Generic;
using System.Web;

namespace PersonalPlayGround.RecipeData.Service
{
    public interface IRecipeService
    {
        List<Recipe> GetRecipes();
        List<Recipe> GetActiveRecipes();
        List<Recipe> GetRecipeBySearch(string search);
        Recipe GetRecipeById(int recipeId);
        Recipe UpdateRecipe(Recipe recipe);
        int AddRecipe(Recipe recipe, HttpPostedFileBase uploadImage);
        void DeleteRecipe(int recipeId);
    }
}
