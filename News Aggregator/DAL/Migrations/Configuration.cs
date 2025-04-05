namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.Context.NewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.Context.NewsContext context)
        {
            //Random rand = new Random();
            //string[] platforms = { "Facebook", "Twitter", "Instagram", "LinkedIn", "Pinterest" };
            //for (int i = 1; i <= 10; i++)
            //{
            //    context.ShareArticles.AddOrUpdate(new EF.Tables.ShareArticle()
            //    {
            //        ArticleId = rand.Next(1,13),
            //        SharedDate = DateTime.Now,
            //        UserId = rand.Next(1, 11),
            //        Platform = platforms[rand.Next(0, platforms.Length)]
            //    });

            //}
            //context.SaveChanges();
        }
    }
}
