using System.Collections.Generic;

namespace PersonalPlayGround.RecepieReviewData
{
    public interface IRecepieReviewService
    {
        List<RecepieReview> GetAllRecepieReviews();
        List<RecepieReview> GetRecepieReviewsByRecepieId(int recepieId);
        void AddRecepieReview(RecepieReview recepieReview, string clientUsername);
    }
}
