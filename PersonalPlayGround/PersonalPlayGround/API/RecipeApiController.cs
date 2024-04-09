using PersonalPlayGround.RecipeData;
using PersonalPlayGround.RecipeData.Service;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace PersonalPlayGround.API
{
    [System.Web.Http.RoutePrefix("api/recipes")]
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

        // GET: api/recipes/get-recipes
        [HttpGet, Route("get-recipes")]
        public List<Recipe> GetRecipes()
        {
            return _recipeService.GetRecipes();
        }

        // GET: api/recipes/get-recipe-by-id/{recipeId}
        [HttpGet, Route("get-recipe-by-id")]
        public Recipe GetRecipeById(int recipeId)
        {
            return _recipeService.GetRecipeById(recipeId);
        }

        // GET: api/recipes/get-recipe-by-search
        [HttpGet, Route("get-recipe-by-search")]
        public List<Recipe> GetRecipeBySearch(string search)
        {
            return _recipeService.GetRecipeBySearch(search);
        }
    }
}