namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usernameTOuserid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BookmarkArticles", name: "Username", newName: "UserId");
            RenameColumn(table: "dbo.ShareArticles", name: "Username", newName: "UserId");
            RenameIndex(table: "dbo.BookmarkArticles", name: "IX_Username", newName: "IX_UserId");
            RenameIndex(table: "dbo.ShareArticles", name: "IX_Username", newName: "IX_UserId");
            AddColumn("dbo.Users", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Username", c => c.String(nullable: false));
            DropColumn("dbo.Users", "UserId");
            RenameIndex(table: "dbo.ShareArticles", name: "IX_UserId", newName: "IX_Username");
            RenameIndex(table: "dbo.BookmarkArticles", name: "IX_UserId", newName: "IX_Username");
            RenameColumn(table: "dbo.ShareArticles", name: "UserId", newName: "Username");
            RenameColumn(table: "dbo.BookmarkArticles", name: "UserId", newName: "Username");
        }
    }
}
