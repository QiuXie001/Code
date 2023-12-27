using System;
using System.Web.Mvc;

namespace BookStore.Filters
{
    public class LoginActionFilter : FilterAttribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            string controllername = filterContext.Controller.ToString();
            string actionname = filterContext.ActionDescriptor.ActionName.ToString();
            if (controllername == "BookStore.Controllers.LoginController")
                return;
            if (controllername == "BookStore.Controllers.ComponentController")
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