using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.RecipeData;
using System.ComponentModel.DataAnnotations;

namespace PersonalPlayGround.Cart
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public Client Client { get; set; }
        public Recipe Recipe { get; set; }
    }
}