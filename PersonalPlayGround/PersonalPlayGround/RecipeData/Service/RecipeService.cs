using PersonalPlayGround.Documents;
using PersonalPlayGround.RecipeData.Repository;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace PersonalPlayGround.RecipeData.Service
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeService(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public List<Recipe> GetRecipes()
        {
            return _recipeRepository.GetRecipes();
        }

        public List<Recipe> GetActiveRecipes()
        {
            return _recipeRepository.GetActiveRecipes();
        }

        public List<Recipe> GetRecipeBySearch(string search)
        {
            return _recipeRepository.GetRecipeBySearch(search);
        }

        public Recipe GetRecipeById(int recipeId)
        {
            Recipe recipe = _recipeRepository.GetRecipeById(recipeId);

            if (string.IsNullOrEmpty(recipe.ImageURL))
            {
                recipe.ImageURL = FileDirectory.Image_Needed;
            }

            return recipe;
        }

        public Recipe GetRecipeWithRelatedDataByRecipeId(int recipeId)
        {
            Recipe recipe = _recipeRepository.GetRecipeWithRelatedDataByRecipeId(recipeId);

            if (string.IsNullOrEmpty(recipe.ImageURL))
            {
                recipe.ImageURL = FileDirectory.Image_Needed;
            }

            return recipe;
        }

        public Recipe UpdateRecipe(Recipe recipe)
        {
            return _recipeRepository.UpdateRecipe(recipe);
        }

        public int AddRecipe(Recipe recipe, HttpPostedFileBase uploadImage)
        {
            if(uploadImage != null)
            {
                UploadHelper.UploadRecipeImage(uploadImage);
                recipe.ImageURL = Path.Combine("~", FileDirectory.RecipesDatabaseFolder, uploadImage.FileName);
            }

            return _recipeRepository.AddRecipe(recipe);
        }

        public void DeleteRecipe(int recipeId)
        {
            _recipeRepository.DeleteRecipe(recipeId);
        }
    }
}