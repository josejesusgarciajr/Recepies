﻿using PersonalPlayGround.RecipeData;
using PersonalPlayGround.RecipeData.Service;
using PersonalPlayGround.RecipeReviewData;
using PersonalPlayGround.RecipeReviewData.Service;
using System;
using System.Web.Mvc;

namespace PersonalPlayGround.Controllers
{
    public class RecipeReviewController : BaseController
    {
        private readonly IRecipeService _recipeService;
        private readonly IRecipeReviewService _recipeReviewService;
        public RecipeReviewController() { }
        public RecipeReviewController(IRecipeService recipeService, IRecipeReviewService recipeReviewService)
        {
            _recipeService = recipeService;
            _recipeReviewService = recipeReviewService;
        }

        [Route("RecipeReview/AddRecipeReview/{recipeId}")]
        public ActionResult AddRecipeReview(int recipeId)
        {
            Recipe recipe = _recipeService.GetRecipeById(recipeId);

            // check if recipe exists
            if (recipe == null)
            {
                return RedirectToAction("Index", "Recipe");
            }

            // check if recipe is active
            if (!recipe.Active)
            {
                return RedirectToAction("Index", "Recipe");
            }

            ViewBag.Recipe = recipe;
            return View();
        }

        public ActionResult AddRecipeReviewToDatabase(RecipeReview recipeReview)
        {
            string clientUsername = User.Identity.Name;
            _recipeReviewService.AddRecipeReview(recipeReview, clientUsername);

            return RedirectToAction("GetRecipeById", "Recipe", new { recipeId = recipeReview.RecipeId, fromPage = "AddRecipeReview" });
        }

        [Route("RecipeReview/UpdateRecipeReview/{recipeReviewId}")]
        public ActionResult UpdateRecipeReview(int recipeReviewId)
        {
            RecipeReview recipeReview = _recipeReviewService.GetRecipeReviewById(recipeReviewId);
            Recipe recipe = _recipeService.GetRecipeById(recipeReview.RecipeId);

            ViewBag.Recipe = recipe;
            return View(recipeReview);
        }

        public ActionResult UpdateRecipeReviewInDatabase(RecipeReview recipeReview)
        {
            recipeReview.ReviewDate = DateTime.Now;
            _recipeReviewService.UpdateRecipeReview(recipeReview);

            return RedirectToAction("GetRecipeById", "Recipe", new { recipeId = recipeReview.RecipeId, fromPage = "UpdateRecipeReview" });
        }
    }
}