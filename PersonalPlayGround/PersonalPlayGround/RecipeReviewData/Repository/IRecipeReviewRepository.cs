using System.Collections.Generic;

namespace PersonalPlayGround.RecipeReviewData.Repository
{
    public interface IRecipeReviewRepository
    {
        RecipeReview GetRecipeReviewById(int recipeReviewId);
        List<RecipeReview> GetAllRecipeReviews();
        List<RecipeReview> GetRecipeReviewsByRecipeId(int recipeId);
        void AddRecipeReview(RecipeReview recipeReview);
        void UpdateRecipeReview(RecipeReview recipeReview);
    }
}