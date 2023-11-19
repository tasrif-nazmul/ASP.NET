using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Z_Hunger.Auth
{
    public class Logged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["Email"] != null)
            {
                return true;
            }

            else
            {
                httpContext.Response.Redirect("~/Home/Login");
                return false;
            }
        }
    }
}