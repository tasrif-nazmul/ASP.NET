using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsAPI.Controllers
{
    public class NewsController : ApiController
    {
        [HttpPost]
        [Route("api/news/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = NewsService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPost]
        [Route("api/news/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = NewsService.Get(id);

                if(data != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, data);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { message = "Not found" });
                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/news/create")]
        public HttpResponseMessage Create(NewsDTO n)
        {
            try
            {
                var data = NewsService.Add(n);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/news/update/{id}")]
        public HttpResponseMessage Update(int id, NewsDTO n)
        {
            try
            {
                if(NewsService.Update(id, n))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Updated successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { message = "You have provide wrong id" });
                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        
        [HttpDelete]
        [Route("api/news/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if(NewsService.Delete(id))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { message = "Deleted successfully" });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, new { message = "News not found" });
                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



    }
}
