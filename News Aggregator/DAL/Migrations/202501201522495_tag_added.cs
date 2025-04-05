namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tag_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Articles", "TgId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "TgId");
            AddForeignKey("dbo.Articles", "TgId", "dbo.Tags", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "TgId", "dbo.Tags");
            DropIndex("dbo.Articles", new[] { "TgId" });
            DropColumn("dbo.Articles", "TgId");
            DropTable("dbo.Tags");
        }
    }
}
