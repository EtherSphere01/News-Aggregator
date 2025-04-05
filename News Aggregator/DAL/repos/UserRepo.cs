using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class UserRepo : Repo, IUserFeature, IUserShare
    {
        public bool AddBookmark(BookmarkArticle bookmark)
        {
            db.BookmarkArticles.Add(bookmark);
            return db.SaveChanges() > 0;
        }

        public bool DeleteBookmark(int id)
        {
            var bookmark = db.BookmarkArticles.Find(id);
            if (bookmark == null)
            {
                return false;
            }
            db.BookmarkArticles.Remove(bookmark);
            db.SaveChanges();
            return true;
        }


        public List<Article> GetBookmarksByUser(int id)
        {
            var bookmarks = (from b in db.BookmarkArticles
                             where b.UserId == id
                             select b).ToList();
            List<Article> articles = new List<Article>();
            foreach (var b in bookmarks)
            {
                var article = db.Articles.Find(b.ArticleId);
                articles.Add(article);
            }
            return articles;
        }
        public List<Article> GetAll()
        {
            var articles = db.Articles.ToList();
            return articles;
        }


        public List<Article> GetByAuthor(string author)
        {
            var articles = (from a in db.Articles
                            where a.Author.Contains(author)
                            select a).ToList();
            return articles;
        }

        public List<Article> GetByDate(DateTime Date)
        {
            var articles = (from a in db.Articles
                            where a.Date == Date
                            select a).ToList();
            return articles;
        }

        public List<Article> GetByTag(string tag)
        {
            var articles = (from a in db.Articles
                            where a.Tag.Contains(tag)
                            select a).ToList();
            return articles;
        }

        public List<Article> GetByTitle(string title)
        {
            var articles = (from a in db.Articles
                            where a.Title.Contains(title)
                            select a).ToList();
            return articles;
        }

        public Article GetArticle(int id)
        {
            return db.Articles.Find(id);
        }

        public List<Article> TrendingNews()
        {
            var articles = db.Articles
                    .Where(a => a.Count > 0)
                    .OrderByDescending(a => a.Date)
                    .ThenByDescending(a => a.Count)
                    .ToList();
            return articles;
        }

        public List<Article> TrendingNews(DateTime date)
        {
            var articles = db.Articles
                    .Where(a => a.Count > 0 && a.Date == date)
                    .OrderByDescending(a => a.Count)
                    .ToList();
            return articles;
        }

        public bool Share(ShareArticle share)
        {
            db.ShareArticles.Add(share);
            return db.SaveChanges() > 0;
        }

        public bool DeleteShare(int id)
        {
            var share = db.ShareArticles.Find(id);
            if (share == null)
            {
                return false;
            }
            db.ShareArticles.Remove(share);
            db.SaveChanges();
            return true;
        }

        public List<ShareArticle> GetShares(int userid)
        {
            var shares = (from s in db.ShareArticles
                          where s.UserId == userid
                          select s).ToList();
            return shares;
        }

        public List<ShareArticle> GetShareByPlatform(string platform, int userid)
        {
            var shares = (from s in db.ShareArticles
                          where s.Platform == platform && s.UserId == userid
                          select s).ToList();
            return shares;

        }
    }
}
