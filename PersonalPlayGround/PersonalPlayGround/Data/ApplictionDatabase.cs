using PersonalPlayGround.ClientInfo;
using PersonalPlayGround.RecepieData;
using PersonalPlayGround.RecepieReviewData;
using System.Data.Entity;

namespace PersonalPlayGround.Data
{
    public class ApplictionDatabase : DbContext
    {
        public DbSet<Recepie> Recepies { get; set; }
        public DbSet<RecepieReview> RecepieReviews { get; set; }
        public DbSet<Client> Clients { get; set; }

        public ApplictionDatabase() : base("name=PersonalPlayGroundDBConnectionString") { }
    }
}
