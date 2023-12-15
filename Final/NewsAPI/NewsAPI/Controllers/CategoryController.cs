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
    public class CategoryController : ApiController
    {
        [HttpGet]
        [Route("api/category/create")]
        public HttpResponseMessage Create(CategoryDTO c)
        {
            try
            {
                var data = CategoryService.Add(c);
                return Request.CreateResponse(HttpStatusCode.OK, new {message="Created Successfully"});

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        [HttpPost]
        [Route("api/category/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = CategoryService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        [HttpPost]
        [Route("api/category/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = CategoryService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("api/category/update/{id}")]
        public HttpResponseMessage Update(int id, CategoryDTO c)
        {
            try
            {
                CategoryService.Update(c, id);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Updated Successfully" });

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



        [HttpDelete]
        [Route("api/category/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var data = CategoryService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, new {message="Deleted Successfully"});

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
