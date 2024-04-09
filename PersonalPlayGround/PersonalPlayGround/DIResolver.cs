using PersonalPlayGround.ClientInfo.Repository;
using PersonalPlayGround.RecipeData;
using PersonalPlayGround.RecipeData.Repository;
using PersonalPlayGround.RecipeData.Service;
using PersonalPlayGround.RecipeReviewData.Repository;
using PersonalPlayGround.RecipeReviewData.Service;
using System.Web.Http;
using System.Web.Mvc;
using Unity;

namespace PersonalPlayGround
{
    public static class DIResolver
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register services and interfaces

            // Recipe
            container.RegisterType<IRecipeRepository, RecipeRepository>();
            container.RegisterType<IRecipeService, RecipeService>();

            // RecipeReviews
            container.RegisterType<IRecipeReviewRepository, RecipeReviewRepository>();
            container.RegisterType<IRecipeReviewService,  RecipeReviewService>();

            // Client
            container.RegisterType<IClientRepository,  ClientRepository>();
            container.RegisterType<IClientService,  ClientService>();

            // set resolver for MVC Controllers
            DependencyResolver.SetResolver(new Unity.AspNet.Mvc.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.AspNet.WebApi.UnityDependencyResolver(container);
        }
    }
}