namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delete_aggregator : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "NewsAggId", "dbo.NewsAggregators");
            DropIndex("dbo.Articles", new[] { "NewsAggId" });
            DropColumn("dbo.Articles", "NewsAggId");
            DropTable("dbo.NewsAggregators");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NewsAggregators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Articles", "NewsAggId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "NewsAggId");
            AddForeignKey("dbo.Articles", "NewsAggId", "dbo.NewsAggregators", "Id", cascadeDelete: true);
        }
    }
}
