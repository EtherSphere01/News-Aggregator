using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    { 
        public static IRepo<Article, int, bool> ArticleData()
        {
            return new ArticleRepo();
        }

        public static IArticleFeature ArticleFeature()
        {
            return new ArticleRepo();
        }

        public static IRepo<Tag, int, bool> TagData()
        {
            return new TagRepo();
        }

        public static ITagFeature TagFeature()
        {
            return new TagRepo();
        }

        public static IUserFeature UserData()
        {
            return new UserRepo();
        }

        public static IUserShare UserShare()
        {
            return new UserRepo();
        }
    }
}
