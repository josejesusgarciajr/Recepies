﻿using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.ClientInfo.Repository;
using PersonalPlayGround.Documents;
using PersonalPlayGround.Models;
using PersonalPlayGround.RecipeData;
using PersonalPlayGround.RecipeData.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalPlayGround.Controllers
{
    [AdminAuthorize]
    [Authorize]
    public class AdminController : BaseController
    {
        private readonly IRecipeService _recipeService;
        private readonly IClientService _clientService;
        public AdminController() { }
        public AdminController(IRecipeService recipeService, IClientService clientService)
        {
            _recipeService = recipeService;
            _clientService = clientService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectRecipe(string modifiedRecipeIds = null)
        {
            List<Recipe> recipes = _recipeService.GetRecipes();

            List<Recipe> activeRecipes = recipes.Where(r => r.Active).ToList();
            List<Recipe> inactiveRecipes = recipes.Where(r => !r.Active).ToList();

            var recipeViewModel = new RecipeViewModel
            {
                ActiveRecipes = activeRecipes,
                InactiveRecipes = inactiveRecipes
            };

            List<int> modifiedIds = new List<int>();

            if (!string.IsNullOrEmpty(modifiedRecipeIds))
            {
                modifiedIds = modifiedRecipeIds
                                .Split(',')
                                .Select(int.Parse)
                                .ToList();
            }


            ViewBag.ModifiedRecipeIds = modifiedIds;

            return View(recipeViewModel);
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
            if (!ModelState.IsValid)
            {
                return View("UpdateRecipe", recipe);
            }

            if (uploadImage  != null)
            {
                UploadHelper.UploadRecipeImage(uploadImage);
                recipe.ImageURL = Path.Combine("~", FileDirectory.RecipesDatabaseFolder, uploadImage.FileName);
            }

            _recipeService.UpdateRecipe(recipe);

            return RedirectToAction("SelectRecipe", "Admin", new { modifiedRecipeIds = recipe.Id });
        }

        public ActionResult InactivateAllWithoutImage()
        {
            List<int> inactiveRecipeIds = _recipeService.InactivateAllWithoutImage();

            // Serialize the list to a comma-separated string
            string serializedIds = string.Join(",", inactiveRecipeIds);

            return RedirectToAction("SelectRecipe", "Admin", new { modifiedRecipeIds = serializedIds });
        }

        public ActionResult AddRecipe()
        {
            return View();
        }

        public ActionResult AddRecipeToDatabase(Recipe recipe, HttpPostedFileBase uploadImage)
        {
            if (!ModelState.IsValid)
            {
                return View("AddRecipe", recipe);
            }

            int newRecipeId = _recipeService.AddRecipe(recipe, uploadImage);

            return RedirectToAction("SelectRecipe", "Admin", new { modifiedRecipeId = newRecipeId });
        }

        public ActionResult DeleteRecipe(int recipeId)
        {
            _recipeService.DeleteRecipe(recipeId);

            return RedirectToAction("SelectRecipe", new { task = "Delete" });
        }

        public ActionResult IdentityUsers()
        {
            List<Client> clients = _clientService.GetAllClients();

            List<Client> adminClients = clients.Where(client => client.IsAdmin).ToList();
            List<Client> regularClients = clients.Where(client => !client.IsAdmin).ToList();

            var identityUsersViewModel = new IdentityUsersViewModel
            {
                AdminClients = adminClients,
                RegularClients = regularClients
            };

            return View(identityUsersViewModel);
        }

        public ActionResult DeleteIdentityUser(string clientId)
        {
            Client client = _clientService.GetClientById(clientId);

            if (client is null)
            {
                return RedirectToAction("IdentityUsers", "Admin");
            }

            AspNetIdentityUser.DeleteAspNetIdentityUser(client.UserName);
            _clientService.RemoveClient(client);

            return RedirectToAction("IdentityUsers", "Admin");
        }
    }
}