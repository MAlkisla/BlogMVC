namespace BlogMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LikeAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        applicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.applicationUser_Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.applicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Likes", "applicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Likes", new[] { "applicationUser_Id" });
            DropIndex("dbo.Likes", new[] { "ArticleId" });
            DropTable("dbo.Likes");
        }
    }
}
