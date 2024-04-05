using System.Collections.Generic;

namespace PersonalPlayGround.RecipeReviewData.Service
{
    public interface IRecipeReviewService
    {
        RecipeReview GetRecipeReviewById(int recipeReviewId);
        List<RecipeReview> GetAllRecipeReviews();
        List<RecipeReview> GetRecipeReviewsByRecipeId(int recipeId);
        void AddRecipeReview(RecipeReview recipeReview, string clientUsername);
        void UpdateRecipeReview(RecipeReview recipeReview);
    }
}
