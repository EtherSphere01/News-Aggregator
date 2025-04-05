namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullchange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Articles", "TgId", "dbo.Tags");
            DropIndex("dbo.Articles", new[] { "TgId" });
            AlterColumn("dbo.Articles", "TgId", c => c.Int());
            CreateIndex("dbo.Articles", "TgId");
            AddForeignKey("dbo.Articles", "TgId", "dbo.Tags", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "TgId", "dbo.Tags");
            DropIndex("dbo.Articles", new[] { "TgId" });
            AlterColumn("dbo.Articles", "TgId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "TgId");
            AddForeignKey("dbo.Articles", "TgId", "dbo.Tags", "Id", cascadeDelete: true);
        }
    }
}
