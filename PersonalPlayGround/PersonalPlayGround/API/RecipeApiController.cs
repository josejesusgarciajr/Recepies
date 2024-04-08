using PersonalPlayGround.RecipeData;
using PersonalPlayGround.RecipeData.Service;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace PersonalPlayGround.API
{
    [RoutePrefix("api/recipeapis")]
    public class RecipeApiController : ApiController
    {
        private readonly IRecipeService _recipeService;
        public RecipeApiController()
        {
            _recipeService = DependencyResolver.Current.GetService<IRecipeService>();
        }
        public RecipeApiController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: RecipeApi
        [System.Web.Http.HttpGet, Route("get-recipes")]
        public List<Recipe> GetRecipes()
        {
            return _recipeService.GetRecipes();
        }

    }
}