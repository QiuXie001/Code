using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using static System.Collections.Specialized.BitVector32;

namespace store
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Application["OnLineUserCount"] = 0;
            Application["UserCount"] = 0;
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }
        private void UpdateOnlineUserCount(int increment)
        {
            Application["OnlineUserCount"] = (int)Application["OnlineUserCount"] + increment;
        }
        private void UpdateUserCount(int increment)
        {
            Application["UserCount"] = (int)Application["UserCount"] + increment;
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            UpdateUserCount(1);
            UpdateOnlineUserCount(1);
        }
        protected void Session_End(object sender, EventArgs e)
        {
            UpdateOnlineUserCount(-1);

        }

        DateTime StartTime;
        protected void Application_BeginRequest()
        {
            var StartTime = DateTime.Now;
            
        }
        protected void Application_EndRequest()
        {
            if (HttpContext.Current.Request.RequestType == "GET")
            {
                var timeSpan = DateTime.Now - StartTime;
                HttpContext.Current.Response.Write($"加载时间{timeSpan.Milliseconds}ms   <br/>" +
                    $"在线用户：{Application["OnLineUserCount"]}人<br/>" +
                    $"累计用户：{Application["UserCount"]}人<br/>");
            }

        }

    }
}