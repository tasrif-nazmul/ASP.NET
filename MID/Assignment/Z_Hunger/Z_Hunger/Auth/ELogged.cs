using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Z_Hunger.Auth
{
    public class ELogged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext.Session["EmployeeEmail"] != null)
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