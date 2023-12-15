using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Services.Description;

namespace NewsAPI.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/user/regester")]
        public HttpResponseMessage Add(UserDTO u)
        {
            try
            {
                var data = UserService.Add(u);
                return Request.CreateResponse(HttpStatusCode.OK, new { message = "Regestered Successfully" }); 
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        
        [HttpPost]
        [Route("api/user/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = UserService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data); 
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
