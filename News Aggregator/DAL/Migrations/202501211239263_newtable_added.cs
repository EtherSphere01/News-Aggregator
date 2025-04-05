namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookmarkArticles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        Username = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Username, cascadeDelete: true)
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShareArticles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        SharedDate = c.DateTime(nullable: false),
                        Platform = c.String(nullable: false),
                        Username = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Username, cascadeDelete: true)
                .Index(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookmarkArticles", "Username", "dbo.Users");
            DropForeignKey("dbo.ShareArticles", "Username", "dbo.Users");
            DropIndex("dbo.ShareArticles", new[] { "Username" });
            DropIndex("dbo.BookmarkArticles", new[] { "Username" });
            DropTable("dbo.ShareArticles");
            DropTable("dbo.Users");
            DropTable("dbo.BookmarkArticles");
        }
    }
}
