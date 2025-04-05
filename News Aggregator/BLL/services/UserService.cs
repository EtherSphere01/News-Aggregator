using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Article, ArticleDTO>();
                cfg.CreateMap<ArticleDTO, Article>();
                cfg.CreateMap<Article, ArticleTagDTO>();
                cfg.CreateMap<ArticleTagDTO, Article>();
                cfg.CreateMap<Tag, TagDTO>();
                cfg.CreateMap<TagDTO, Tag>();
                cfg.CreateMap<BookmarkArticle, BookmarkArticleDTO>();
                cfg.CreateMap<BookmarkArticleDTO, BookmarkArticle>();
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<UserBookmarkArticleDTO, User>();
                cfg.CreateMap<User, UserBookmarkArticleDTO>();
                cfg.CreateMap<ShareArticle, ShareDTO>();
                cfg.CreateMap<ShareDTO, ShareArticle>();
                cfg.CreateMap<ShareUserDTO, ShareArticle>();
                cfg.CreateMap<ShareArticle, ShareUserDTO>();    
                cfg.CreateMap<UserShareDTO, ShareArticle>();
                cfg.CreateMap<ShareArticle, UserShareDTO>();
                cfg.CreateMap<User, UserShareDTO>();
                cfg.CreateMap<UserShareDTO, User>();
                cfg.CreateMap<UserShareDTO, ShareDTO>();
                cfg.CreateMap<ShareDTO, UserShareDTO>();



            });
            return new Mapper(config);
        }

        public List<ArticleDTO> GetAll()
        {
            var repo = DataAccessFactory.UserData();
            return GetMapper().Map<List<ArticleDTO>>(repo.GetAll());
        }

        public List<ArticleDTO> GetByTag(string tag)
        {
            var repo = DataAccessFactory.UserData();
            return GetMapper().Map<List<ArticleDTO>>(repo.GetByTag(tag));
        }

        public List<ArticleDTO> GetByAuthor(string author)
        {
            var repo = DataAccessFactory.UserData();
            return GetMapper().Map<List<ArticleDTO>>(repo.GetByAuthor(author));
        }

        public List<ArticleDTO> GetByDate(DateTime date)
        {
            var repo = DataAccessFactory.UserData();
            return GetMapper().Map<List<ArticleDTO>>(repo.GetByDate(date));
        }

        public List<ArticleDTO> GetByTitle(string title)
        {
            var repo = DataAccessFactory.UserData();
            return GetMapper().Map<List<ArticleDTO>>(repo.GetByTitle(title));
        }

        public bool AddBookmark(int userId, int articleId)
        {
            var bookmark = new BookmarkArticle
            {
                ArticleId = articleId,
                UserId = userId,
                CreatedAt = DateTime.Now.Date,
                DeletedAt = null
            };
            var repo = DataAccessFactory.UserData();
            return repo.AddBookmark(bookmark);
        }

        public bool DeleteBookmark(int id)
        {
            var repo = DataAccessFactory.UserData();
            return repo.DeleteBookmark(id);
        }

        public List<ArticleDTO> GetBookmarksByUser(int id)
        {
            var repo = DataAccessFactory.UserData();
            return GetMapper().Map<List<ArticleDTO>>(repo.GetBookmarksByUser(id));
        }

        public ArticleDTO GetArticle(int id)
        {
            var repo = DataAccessFactory.UserData();
            var repo2 = DataAccessFactory.ArticleFeature();
            var data = GetMapper().Map<ArticleDTO>(repo.GetArticle(id));
            if(data != null)
            {
                repo2.UpdateTrending(id);
            }
            return data;
        }

        public List<ArticleDTO> TrendingNews()
        {
            var repo = DataAccessFactory.UserData();
            return GetMapper().Map<List<ArticleDTO>>(repo.TrendingNews());
        }

        public List<ArticleDTO> TrendingNews(int N)
        {
            var repo = DataAccessFactory.UserData();
            var data = GetMapper().Map<List<ArticleDTO>>(repo.TrendingNews());
            List<ArticleDTO> articles = new List<ArticleDTO>();
            if(data.Count < N)
            {
                N = data.Count;
            }

            for (int i = 0; i < N; i++)
            {
                articles.Add(data[i]);
            }
            return articles;
        }

        public List<ArticleDTO> TrendingNews(DateTime date)
        {
            var repo = DataAccessFactory.UserData();
            return GetMapper().Map<List<ArticleDTO>>(repo.TrendingNews(date));

        }

        public bool Share(int userId, int articleId, string platform)
        {
            var share = new ShareArticle
            {
                ArticleId = articleId,
                UserId = userId,
                SharedDate = DateTime.Now.Date,
                Platform = platform
            };
            var repo = DataAccessFactory.UserShare();
            var data = GetMapper().Map<ShareArticle>(share);
            return repo.Share(data);
        }

        public bool DeleteShare(int id)
        {
            var repo = DataAccessFactory.UserShare();
            return repo.DeleteShare(id);
        }

        public List<ArticleDTO> GetShares(int userid)
        {
            var repo = DataAccessFactory.UserShare();
            var data = GetMapper().Map<List<ShareDTO>>(repo.GetShares(userid));
            var articles = new List<ArticleDTO>();
            foreach (var item in data)
            {
                var repo2 = DataAccessFactory.UserData();
                var article = repo2.GetArticle(item.ArticleId);
                articles.Add(GetMapper().Map<ArticleDTO>(article));
            }
            return articles;
        }

        public List<ArticleDTO> GetShareByPlatform(string platform, int userid)
        {
            var repo = DataAccessFactory.UserShare();
            var data = GetMapper().Map<List<ShareDTO>>(repo.GetShareByPlatform(platform, userid));
            var articles = new List<ArticleDTO>();
            foreach (var item in data)
            {
                var repo2 = DataAccessFactory.UserData();
                var article = repo2.GetArticle(item.ArticleId);
                articles.Add(GetMapper().Map<ArticleDTO>(article));
            }
            return articles;
        }

        ///////////////////////CSV///////////////////////////////
        public string GenerateCsvForApplications(DateTime date)
        {
            var csvBuilder = new StringBuilder();

            var applications = DataAccessFactory.UserData();
            var data = applications.GetByDate(date);

            csvBuilder.AppendLine("Content,Author,Date,Tag");

            foreach (var i in data)
            {
                csvBuilder.AppendLine($"{i.Content},{i.Author},{i.Date},{i.Tag}");

            }

            return csvBuilder.ToString();
        }


    }
}
