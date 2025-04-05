using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Net.Http.Headers;

namespace News_Aggregator.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/user/getbytag/{tag}")]
        public HttpResponseMessage GetByTag(string tag)
        {
            var service = new UserService();
            var data = service.GetByTag(tag);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/getbyauthor/{author}")]
        public HttpResponseMessage GetByAuthor(string author)
        {
            var service = new UserService();
            var data = service.GetByAuthor(author);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/getbydate/{date}")]
        public HttpResponseMessage GetByDate(DateTime date)
        {
            var service = new UserService();
            var data = service.GetByDate(date);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/getbytitle/{title}")]
        public HttpResponseMessage GetByTitle(string title)
        {
            var service = new UserService();
            var data = service.GetByTitle(title);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/getall")]
        public HttpResponseMessage GetAll()
        {
            var service = new UserService();
            var data = service.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/bookmark/{userId}/{articleId}")]
        public HttpResponseMessage AddBookmark(int userId, int articleId)
        {
            var service = new UserService();
            var data = service.AddBookmark(userId, articleId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/deletebookmark/{id}")]
        public HttpResponseMessage DeleteBookmark(int id)
        {
            var service = new UserService();
            var data = service.DeleteBookmark(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/user/getbookmarksbyuser/{id}")]
        public HttpResponseMessage GetBookmarksByUser(int id)
        {
            var service = new UserService();
            var data = service.GetBookmarksByUser(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/getarticle/{id}")]
        public HttpResponseMessage GetArticle(int id)
        {
            var service = new UserService();
            var data = service.GetArticle(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/trendingnews")]
        public HttpResponseMessage TrendingNews()
        {
            var service = new UserService();
            var data = service.TrendingNews();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/ntrendingnews/{count}")]
        public HttpResponseMessage NTrendingNews(int count)
        {
            var service = new UserService();
            var data = service.TrendingNews(count);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/dtrendingnews/{date}")]
        public HttpResponseMessage DTrendingNews(DateTime date)
        {
            var service = new UserService();
            var data = service.TrendingNews(date);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/share/{userId}/{articleId}/{platform}")]
        public HttpResponseMessage Share(int userId, int articleId, string platform)
        {
            var service = new UserService();
            var data = service.Share(userId, articleId, platform);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/deleteshare/{id}")]
        public HttpResponseMessage DeleteShare(int id)
        {
            var service = new UserService();
            var data = service.DeleteShare(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/getshares/{userId}")]
        public HttpResponseMessage GetShares(int userId)
        {
            var service = new UserService();
            var data = service.GetShares(userId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/user/getsharebyplatform/{platform}/{userId}")]
        public HttpResponseMessage GetShareByPlatform(string platform, int userId)
        {
            var service = new UserService();
            var data = service.GetShareByPlatform(platform, userId);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        //////////////////////////////csv/////////////////////////////
        [HttpGet]
        [Route("api/user/export/{date}")]
        public HttpResponseMessage ExportApplicationsToCsv(DateTime date)
        {
            var service = new UserService();
            var csvContent = service.GenerateCsvForApplications(date);

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(csvContent, Encoding.UTF8, "text/csv")
            };
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = "Article.csv"
            };

            return result;
        }
    }
}
