using PersonalPlayGround.RecipeData;
using PersonalPlayGround.RecipeData.Service;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;

namespace PersonalPlayGround.API
{
    [System.Web.Http.RoutePrefix("api/recipeapis")]
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

        // GET: api/recipeapis/get-recipes
        [System.Web.Http.HttpGet, System.Web.Http.Route("get-recipes")]
        [SwaggerOperation("GetRecipes")]
        public List<Recipe> GetRecipes()
        {
            return _recipeService.GetRecipes();
        }

        // GET: api/recipeapis/get-recipe-by-id/{recipeId}
        [System.Web.Http.HttpGet, System.Web.Http.Route("get-recipe-by-id")]
        public Recipe GetRecipeById(int recipeId)
        {
            return _recipeService.GetRecipeById(recipeId);
        }
    }
}