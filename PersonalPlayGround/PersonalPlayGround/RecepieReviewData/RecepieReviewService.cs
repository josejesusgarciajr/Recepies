using PersonalPlayGround.ClientInfo;
using System;
using System.Collections.Generic;

namespace PersonalPlayGround.RecepieReviewData
{
    public class RecepieReviewService : IRecepieReviewService
    {
        private readonly IRecepieReviewRepository _recepieReviewRepository;
        private readonly IClientService _clientService;
        public RecepieReviewService() { }
        public RecepieReviewService(IRecepieReviewRepository recepieReviewRepository, IClientService clientService)
        {
            _recepieReviewRepository = recepieReviewRepository;
            _clientService = clientService;
        }

        public void AddRecepieReview(RecepieReview recepieReview, string clientUsername)
        {
            recepieReview.ReviewDate = DateTime.UtcNow;
            recepieReview.Client = _clientService.GetClientByUsername(clientUsername);

            _recepieReviewRepository.AddRecepieReview(recepieReview);
        }

        public List<RecepieReview> GetAllRecepieReviews()
        {
            return _recepieReviewRepository.GetAllRecepieReviews();
        }

        public List<RecepieReview> GetRecepieReviewsByRecepieId(int recepieId)
        {
            return _recepieReviewRepository.GetRecepieReviewsByRecepieId(recepieId);
        }
    }
}