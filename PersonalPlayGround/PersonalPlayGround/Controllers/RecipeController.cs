using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.ClientInfo.Repository;
using PersonalPlayGround.RecipeData;
using PersonalPlayGround.RecipeData.Service;
using PersonalPlayGround.RecipeReviewData.Service;

namespace PersonalPlayGround.Controllers
{
    [Authorize]
    public class RecipeController : BaseController
    {
        private readonly IRecipeService _recipeService;
        private readonly IRecipeReviewService _recipeReviewService;
        private readonly IClientService _clientService;

        private Queue<DateTime> SkippedSongsDateTime { get; set; } = new Queue<DateTime>();
        public RecipeController() { }
        public RecipeController(IRecipeService recipeService, IRecipeReviewService recipeReviewService, IClientService clientService)
        {
            _recipeService = recipeService;
            _recipeReviewService = recipeReviewService;
            _clientService = clientService;
        }

        // GET: Recipe
        public ActionResult Index()
        {
            List<Recipe> recipes = _recipeService.GetActiveRecipes();

            return View(recipes);
        }

        // GET: Recipe/Id
        [Route("Recipe/{recipeId}")]
        public ActionResult GetRecipeById(int? recipeId, string fromPage = "")
        {
            if (recipeId == null)
            {
                return Index();
            }

            Recipe recipe = _recipeService.GetRecipeWithRelatedDataByRecipeId(recipeId.Value);

            // check if recipe exists or if recipe is inactive
            if(recipe == null || !recipe.Active)
            {
                return RedirectToAction("Index", "Recipe");
            }

            // Check if client left a review 
            Client client = _clientService.GetClientByUsername(User.Identity.Name);
            bool clientLeftReview = _clientService.ClientLeftReview(client.Id, recipeId.Value);

            // Confett logic
            bool showConfetti = false;
            if(fromPage.Equals("AddRecipeReview") || fromPage.Equals("UpdateRecipeReview"))
            {
                showConfetti = true;
            }

            ViewBag.ShowConfetti = showConfetti;
            ViewBag.ClientLeftReview = clientLeftReview;

            return View(recipe);
        }

    }
}