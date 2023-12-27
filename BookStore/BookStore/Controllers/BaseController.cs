using DBLibrary.bill;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                var exception = filterContext.Exception;

                // 创建 ErrorMessage 对象并设置错误信息  
                var errorMessage = new ErrorMessage
                {
                    ErrorMsg = exception.Message
                };

                // 将 ErrorMessage 对象传递给临时页面  
                filterContext.Controller.ViewBag.ErrorMessage = errorMessage;

                // 设置默认的视图引擎器  
                filterContext.Controller.TempData["ErrorMessage"] = errorMessage;
            }
        }
    }
}