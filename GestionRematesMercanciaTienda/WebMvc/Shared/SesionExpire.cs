using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebMvc.Menu
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CheckSessionOutAttribute : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var context = filterContext.HttpContext;
        //    if (context.Session != null)
        //    {
        //        if (context.Session.IsNewSession)
        //        {
        //            string sessionCookie = context.Request.Headers["Cookie"];

        //            if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
        //            {
        //                FormsAuthentication.SignOut();
        //                string redirectTo = "~/Account/Login";
        //                if (!string.IsNullOrEmpty(context.Request.RawUrl))
        //                {
        //                    redirectTo = string.Format("~/Account/Login?ReturnUrl={0}",
        //                       /// HttpUtility.UrlEncode(context.Request.RawUrl));
        //                       HttpUtility.UrlEncode("http://tdaqalegsap337/login"));
        //                }


        //            }
        //        }
        //    }

        //    base.OnActionExecuting(filterContext);
        //}

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            // check  sessions here
            //if (HttpContext.Current.Session["cookieSeguridad"] == null)
            //{
            //    filterContext.Result = new RedirectResult("http://tdaqalegsap337/login");
            //    return;
            //}



            if (filterContext.HttpContext.Request.Cookies.AllKeys.Contains("CookieLogin"))
            {
                filterContext.Result = new RedirectResult("http://tdaqalegsap337/recibo");
                return;

            }
            else {
                filterContext.Result = new RedirectResult("http://tdaqalegsap337/login");
                return;
            }


            base.OnActionExecuting(filterContext);
        }
    }
}