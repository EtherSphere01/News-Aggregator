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
    public class TagController : ApiController
    {
        [HttpPost]
        [Route("api/Tag/get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var service = new TagService();
            var data = service.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpGet]
        [Route("api/Tag/getall")]
        public HttpResponseMessage GetAll()
        {
            var service = new TagService();
            var data = service.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/Tag/create")]
        public HttpResponseMessage Create(TagDTO tag)
        {
            var service = new TagService();
            var data = service.Create(tag);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("api/Tag/update")]
        public HttpResponseMessage Update(TagDTO tag)
        {
            var service = new TagService();
            var data = service.Update(tag);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}
