using PersonalPlayGround.RecipeData;
using PersonalPlayGround.RecipeData.Service;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
//using System.Web.Http;
using System.Web.Mvc;

namespace PersonalPlayGround.API
{
    [RoutePrefix("api/recipeapis")]
    public class RecipeApiController : System.Web.Http.ApiController
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
        [HttpGet, Route("get-all")]
        [SwaggerOperation("GetRecipes")]
        public List<Recipe> GetRecipes()
        {
            return _recipeService.GetRecipes();
        }

        //// GET: api/recipeapis/get-recipe-by-id/{recipeId}
        //[System.Web.Http.HttpGet, Route("get-recipe-by-id")]
        //public Recipe GetRecipeById(int recipeId)
        //{
        //    return _recipeService.GetRecipeById(recipeId);
        //}
    }
}