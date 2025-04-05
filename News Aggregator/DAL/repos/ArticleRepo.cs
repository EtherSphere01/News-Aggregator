using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ArticleRepo : Repo, IRepo<Article, int, bool>,IArticleFeature
    {

        public bool Create(Article obj)
        {
            db.Articles.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var article = db.Articles.Find(id);
            db.Articles.Remove(article);
            return db.SaveChanges() > 0;
        }

        public Article Get(int id)
        {
            return db.Articles.Find(id);
        }

        public List<Article> GetAll()
        {
            var articles = db.Articles.ToList();
            return articles;
        }

        public bool Update(Article obj)
        {
            var article = db.Articles.Find(obj.Id);
            article.Title = obj.Title;
            article.Content = obj.Content;
            article.Date = obj.Date;
            article.Author = obj.Author;
            article.Tag = obj.Tag;
            article.TgId = obj.TgId;
            return db.SaveChanges() > 0;
        }

        public List<Article> UpdateTag(int tgid)
        {
            var article = (from a in db.Articles
                           where a.TgId == tgid
                           select a).ToList();
            return article;
        }

        public void UpdateTrending(int id)
        {
            var article = db.Articles.Find(id);
            article.Count++;
            db.SaveChanges();
        }
    }
}
