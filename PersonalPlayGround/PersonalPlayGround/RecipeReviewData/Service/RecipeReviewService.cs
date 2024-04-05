using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.ClientInfo.Repository;
using PersonalPlayGround.RecipeReviewData.Repository;
using System;
using System.Collections.Generic;

namespace PersonalPlayGround.RecipeReviewData.Service
{
    public class RecipeReviewService : IRecipeReviewService
    {
        private readonly IRecipeReviewRepository _recipeReviewRepository;
        private readonly IClientService _clientService;
        public RecipeReviewService() { }
        public RecipeReviewService(IRecipeReviewRepository recipeReviewRepository, IClientService clientService)
        {
            _recipeReviewRepository = recipeReviewRepository;
            _clientService = clientService;
        }

        public void AddRecipeReview(RecipeReview recipeReview, string clientUsername)
        {
            recipeReview.ReviewDate = DateTime.UtcNow;
            Client client = _clientService.GetClientByUsername(clientUsername);
            recipeReview.ClientId = client.Id;

            _recipeReviewRepository.AddRecipeReview(recipeReview);
        }

        public RecipeReview GetRecipeReviewById(int recipeReviewId)
        {
            return _recipeReviewRepository.GetRecipeReviewById(recipeReviewId);
        }

        public List<RecipeReview> GetAllRecipeReviews()
        {
            return _recipeReviewRepository.GetAllRecipeReviews();
        }

        public List<RecipeReview> GetRecipeReviewsByRecipeId(int recipeId)
        {
            return _recipeReviewRepository.GetRecipeReviewsByRecipeId(recipeId);
        }

        public void UpdateRecipeReview(RecipeReview recipeReview)
        {
            _recipeReviewRepository.UpdateRecipeReview(recipeReview);
        }
    }
}