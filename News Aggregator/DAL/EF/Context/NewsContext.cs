using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Context
{
    public class NewsContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ShareArticle> ShareArticles { get; set; }
        public DbSet<BookmarkArticle> BookmarkArticles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
