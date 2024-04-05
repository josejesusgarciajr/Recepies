using System.Collections.Generic;

namespace PersonalPlayGround.RecepieReviewData.Repository
{
    public interface IRecepieReviewRepository
    {
        RecepieReview GetRecepieReviewById(int recepieReviewId);
        List<RecepieReview> GetAllRecepieReviews();
        List<RecepieReview> GetRecepieReviewsByRecepieId(int recepieId);
        void AddRecepieReview(RecepieReview recepieReview);
        void UpdateRecepieReview(RecepieReview recepieReview);
    }
}