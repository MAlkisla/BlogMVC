namespace BlogMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutthorString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Author");
        }
    }
}
