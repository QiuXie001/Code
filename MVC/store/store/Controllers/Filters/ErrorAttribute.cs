using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace store.Filters
{
    public class ErrorAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            string msg = "";
            if (filterContext.Exception != null)
                msg += filterContext.Exception.Message;
            if (filterContext.Exception.InnerException != null)
                msg += filterContext.Exception.InnerException.Message;
            filterContext.HttpContext.Session["errorMsg"] = msg;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectResult("/Error/Error");
        }
    }
}