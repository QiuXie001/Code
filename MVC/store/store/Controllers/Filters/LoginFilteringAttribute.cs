using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace store.Filters
{
    public class LoginFilteringAttribute : FilterAttribute, IAuthorizationFilter
    {
        
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string controllername = filterContext.Controller.ToString();
            string actionname = filterContext.ActionDescriptor.ActionName.ToString();
            if (controllername == "store.Controllers.LoginController")
                return;
            
            if (filterContext.HttpContext.Session["isLogin"] == null)
            {
                // 获取登录页面的 URL
                string loginUrl = "/Login/Login";

                // 检查当前请求的 URL 是否是登录页面
                bool isRequestingLoginPage = filterContext.HttpContext.Request.Url.AbsolutePath.Equals(loginUrl, StringComparison.OrdinalIgnoreCase);

                if (!isRequestingLoginPage)
                {
                    // 重定向到登录页面
                    filterContext.Result = new RedirectResult(loginUrl);
                    return;
                }
            }
        }

    }
}