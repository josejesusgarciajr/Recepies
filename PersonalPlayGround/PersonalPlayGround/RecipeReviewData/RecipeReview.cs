using System;
using System.ComponentModel.DataAnnotations;
using PersonalPlayGround.ClientInfo;

namespace PersonalPlayGround.RecipeReviewData
{
    public class RecipeReview
    {
        [Key]
        public int RecipeReviewId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public double Rating { get; set; }
        public string Review { get; set; }
        public DateTime ReviewDate { get; set; }
        public int RecipeId { get; set; }
    }
}