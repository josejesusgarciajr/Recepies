using System;
using System.ComponentModel.DataAnnotations;
using PersonalPlayGround.ClientInfo;

namespace PersonalPlayGround.RecepieReviewData
{
    public class RecepieReview
    {
        [Key]
        public int RecepieReviewId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
        public DateTime ReviewDate { get; set; }
        public int RecepieId { get; set; }
    }
}