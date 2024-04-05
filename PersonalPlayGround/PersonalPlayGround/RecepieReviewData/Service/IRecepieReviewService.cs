using System.Collections.Generic;

namespace PersonalPlayGround.RecepieReviewData.Service
{
    public interface IRecepieReviewService
    {
        RecepieReview GetRecepieReviewById(int recepieReviewId);
        List<RecepieReview> GetAllRecepieReviews();
        List<RecepieReview> GetRecepieReviewsByRecepieId(int recepieId);
        void AddRecepieReview(RecepieReview recepieReview, string clientUsername);
        void UpdateRecepieReview(RecepieReview recepieReview);
    }
}
