using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.RecipeData;
using PersonalPlayGround.RecipeReviewData;
using System.Data.Entity;

namespace PersonalPlayGround.Data
{
    public class ApplictionDatabase : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeReview> RecipeReviews { get; set; }
        public DbSet<Client> Clients { get; set; }

        public ApplictionDatabase() : base("name=PersonalPlayGroundDBConnectionString") { }
    }
}
