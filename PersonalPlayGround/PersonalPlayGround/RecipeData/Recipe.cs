using PersonalPlayGround.RecipeReviewData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalPlayGround.RecipeData
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Recipe Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public List<string> Ingridients { get; set; }
        public List<RecipeReview> Ratings { get; set; }
        public bool Active { get; set; } = true;
    }
}