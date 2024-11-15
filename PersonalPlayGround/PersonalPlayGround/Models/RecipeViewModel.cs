using PersonalPlayGround.RecipeData;
using System.Collections.Generic;

namespace PersonalPlayGround.Models
{
    public class RecipeViewModel
    {
        public List<Recipe> ActiveRecipes { get; set; }
        public List<Recipe> InactiveRecipes { get; set; }
    }
}