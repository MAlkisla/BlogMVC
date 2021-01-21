namespace BlogMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentUserNameAndId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.Comments", name: "IX_User_Id", newName: "IX_ApplicationUserId");
            AddColumn("dbo.Comments", "CommentAuthor", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "CommentAuthor");
            RenameIndex(table: "dbo.Comments", name: "IX_ApplicationUserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Comments", name: "ApplicationUserId", newName: "User_Id");
        }
    }
}
