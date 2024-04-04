using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.ClientInfo.Repository;
using PersonalPlayGround.RecepieReviewData.Repository;
using System;
using System.Collections.Generic;

namespace PersonalPlayGround.RecepieReviewData.Service
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
            Client client = _clientService.GetClientByUsername(clientUsername);
            recepieReview.ClientId = client.Id;

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