using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserFeature
    {
        List<Article> GetByTag(string tag);
        List<Article> GetByDate(DateTime Date);
        List<Article> GetByAuthor(string author);
        List<Article> GetByTitle(string title);
        List<Article> GetAll();
        bool AddBookmark(BookmarkArticle bookmark);
        bool DeleteBookmark(int id);
        List<Article> GetBookmarksByUser(int id);
        Article GetArticle(int id);
        List<Article> TrendingNews();
        List<Article> TrendingNews(DateTime date);
    }
}
