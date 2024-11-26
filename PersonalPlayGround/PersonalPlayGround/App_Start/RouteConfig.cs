using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace PersonalPlayGround
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // custom routing for GetRecipeById: Recipe Controller
            routes.MapRoute(
                name: "Recipe",
                url: "Recipe/{recipeId}",
                defaults: new { controller = "Recipe", action = "GetRecipeById" },
                constraints: new { recipeId = @"\d+" } // Ensure 'id' is numeric
            );

            // custom routing for AddRecipeReview: RecipeReview Controller
            routes.MapRoute(
                name: "AddRecipeReview",
                url: "RecipeReview/AddRecipeReview/{recipeId}",
                defaults: new { controller = "RecipeReview", action = "AddRecipeReview" },
                constraints: new { recipeId = @"\d+" } // Ensure 'id' is numeric
            );

            routes.MapRoute(
                name: "UpdateRecipeReview",
                url: "RecipeReview/UpdateRecipeReview/{recipeReviewId}",
                defaults: new { controller = "RecipeReview", action = "UpdateRecipeReview" },
                constraints: new { recipeReviewId = @"\d+" }
            );

            // default routing
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
