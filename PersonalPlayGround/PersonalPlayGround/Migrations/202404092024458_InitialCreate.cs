namespace PersonalPlayGround.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        UserName = c.String(nullable: false, maxLength: 100),
                        PasswordHash = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.RecipeReviews",
                c => new
                    {
                        RecipeReviewId = c.Int(nullable: false, identity: true),
                        ClientId = c.String(maxLength: 128),
                        Rating = c.Double(nullable: false),
                        Review = c.String(),
                        ReviewDate = c.DateTime(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecipeReviewId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageURL = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeReviews", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.RecipeReviews", "ClientId", "dbo.Clients");
            DropIndex("dbo.RecipeReviews", new[] { "RecipeId" });
            DropIndex("dbo.RecipeReviews", new[] { "ClientId" });
            DropIndex("dbo.Clients", new[] { "UserName" });
            DropTable("dbo.Recipes");
            DropTable("dbo.RecipeReviews");
            DropTable("dbo.Clients");
        }
    }
}
