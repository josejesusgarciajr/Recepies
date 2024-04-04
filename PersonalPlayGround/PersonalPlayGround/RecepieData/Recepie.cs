using PersonalPlayGround.RecepieReviewData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalPlayGround.RecepieData
{
    public class Recepie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public List<string> Ingridients { get; set; }
        public List<RecepieReview> Ratings { get; set; }
        public bool Active { get; set; } = true;
    }
}