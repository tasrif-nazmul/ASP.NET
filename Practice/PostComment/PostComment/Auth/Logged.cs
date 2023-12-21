using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PostComment.Auth
{
    public class Logged : AuthorizationFilterAttribute //This is parent class comes from System.Web
    {
        public override void OnAuthorization(HttpActionContext actionContext) //actionContext er url er parameter, return type and headers cole ashbe
        {
            var token = actionContext.Request.Headers.Authorization;
            if(token == null)
            {
                //headers comes autometically but we can modify it
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new {message="No token supplied"});
            }
            else if(!AuthService.IsTokenValid(token.ToString()))
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { message = "Supplied token is Invalid or Expired" });
            }

            base.OnAuthorization(actionContext);    
        }
    }
}