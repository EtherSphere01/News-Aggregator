namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Tag = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        Count = c.Int(nullable: false),
                        NewsAggId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.NewsAggregators", t => t.NewsAggId, cascadeDelete: true)
                .Index(t => t.NewsAggId);
            
            CreateTable(
                "dbo.NewsAggregators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "NewsAggId", "dbo.NewsAggregators");
            DropIndex("dbo.Articles", new[] { "NewsAggId" });
            DropTable("dbo.NewsAggregators");
            DropTable("dbo.Articles");
        }
    }
}
