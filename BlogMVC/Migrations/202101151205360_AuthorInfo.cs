namespace BlogMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AuthorInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "AuthorInfo", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "AuthorInfo");
        }
    }
}
