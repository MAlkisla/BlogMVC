namespace BlogMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorColums : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AuthorPhoto", c => c.String());
            AddColumn("dbo.AspNetUsers", "AuthorName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AuthorName");
            DropColumn("dbo.AspNetUsers", "AuthorPhoto");
        }
    }
}
