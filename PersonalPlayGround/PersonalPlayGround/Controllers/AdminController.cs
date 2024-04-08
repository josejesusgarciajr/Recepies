using PersonalPlayGround.Documents;
using PersonalPlayGround.RecipeData;
using PersonalPlayGround.RecipeData.Service;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace PersonalPlayGround.Controllers
{
    [Authorize]
    public class AdminController : BaseController
    {
        private readonly IRecipeService _recipeService;
        public AdminController() { }
        public AdminController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectRecipe(string task)
        {
            ViewData["Action"] = task;
            List<Recipe> recipes = _recipeService.GetRecipes();

            return View(recipes);
        }

        public ActionResult UpdateRecipe(int recipeId)
        {
            Recipe recipe = _recipeService.GetRecipeById(recipeId);

            if(string.IsNullOrEmpty(recipe.ImageURL))
            {
                recipe.ImageURL = Path.Combine("~", FileDirectory.RecipesDatabaseFolder, FileDirectory.Image_Needed);
            }

            return View(recipe);
        }

        public ActionResult UpdateRecipeInDatabase(Recipe recipe, HttpPostedFileBase uploadImage)
        {
            if (uploadImage  != null)
            {
                UploadHelper.UploadRecipeImage(uploadImage);
                recipe.ImageURL = Path.Combine("~", FileDirectory.RecipesDatabaseFolder, uploadImage.FileName);
            }

            _recipeService.UpdateRecipe(recipe);

            return RedirectToAction("GetRecipeById", "Recipe", new { recipeId = recipe.Id });
        }

        public ActionResult AddRecipe()
        {
            return View();
        }

        public ActionResult AddRecipeToDatabase(Recipe recipe, HttpPostedFileBase uploadImage)
        {
            int newRecipeId = _recipeService.AddRecipe(recipe, uploadImage);

            return RedirectToAction("GetRecipeById", "Recipe", new { recipeId = newRecipeId });
        }

        public ActionResult DeleteRecipe(int recipeId)
        {
            _recipeService.DeleteRecipe(recipeId);

            return RedirectToAction("SelectRecipe", new { task = "Delete" });
        }
    }
}