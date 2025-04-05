using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace News_Aggregator.Controllers
{
    public class ArticleController : ApiController
    {
        [HttpPost]
        [Route("api/Article/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var service = new ArticleService();
            var data = service.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/Article/getall")]
        public HttpResponseMessage GetAll()
        {
            var service = new ArticleService();
            var data = service.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/Article/create")]
        public HttpResponseMessage Create(ArticleDTO article)
        {
            var service = new ArticleService();
            var data = service.Create(article);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/Article/update")]
        public HttpResponseMessage Update(ArticleDTO article)
        {
            var service = new ArticleService();
            var data = service.Update(article);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [HttpPost]
        [Route("api/Article/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            var service = new ArticleService();
            var data = service.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

    }
}
