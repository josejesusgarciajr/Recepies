using PersonalPlayGround.RecipeData;
using PersonalPlayGround.RecipeData.Service;
using System.Collections.Generic;
using System.Web.Http;

namespace PersonalPlayGround.API
{
    [RoutePrefix("api/recipeapis")]
    public class RecipeApiController : ApiController
    {
        private readonly IRecipeService _recipeService;

        public RecipeApiController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: api/recipeapis/get-recipes
        [HttpGet, Route("get-all")]
        public List<Recipe> GetRecipes()
        {
            return _recipeService.GetRecipes();
        }

        // GET: api/recipeapis/get-recipe-by-id/{recipeId}
        [HttpGet, Route("get-recipe-by-id/{recipeId}")]
        public Recipe GetRecipeById(int recipeId)
        {
            return _recipeService.GetRecipeById(recipeId);
        }
    }
}