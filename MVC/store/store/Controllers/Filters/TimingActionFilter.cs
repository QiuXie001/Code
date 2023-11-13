using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.EnterpriseServices.Internal;
using System.Web;
using System.Web.Mvc;

namespace store.Uitl.Filters
{

    public class ThreadInfoModel
    {
        public string str { get; set; }
        public Stopwatch Stopwatch { get; set; }
        public string Url { get; set; }
    }

    public class TimingActionFilter : ActionFilterAttribute
    {
        private static readonly ConcurrentDictionary<int, ThreadInfoModel> _threadInfo = new ConcurrentDictionary<int, ThreadInfoModel>();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // 过滤掉ChildAction，因为ChildAction实际上不是一个单独的页面
            if (filterContext.IsChildAction) return;
            var currentThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;

            var model = new ThreadInfoModel
            {
                str = "传递测试",
                Stopwatch = Stopwatch.StartNew(),
                Url = filterContext.HttpContext.Request.Url == null ? string.Empty : filterContext.HttpContext.Request.Url.AbsoluteUri
            };
            _threadInfo.TryAdd(currentThreadId, model);
        }

        public static String Timing ="123";
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var currentThreadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            ThreadInfoModel model;
            bool isFind = _threadInfo.TryGetValue(currentThreadId, out model);
            if (!isFind || model == null)
            {
                return;
            }

            // 停止计时并获取计时结果
            model.Stopwatch.Stop();
            System.Diagnostics.Debug.WriteLine(model.str);
            var timeSpan = model.Stopwatch.Elapsed.TotalMilliseconds;
            Timing = timeSpan.ToString();
            HttpContext.Current.Session["Timing"] = timeSpan;
            _threadInfo.TryRemove(currentThreadId, out model);
        }
    }
}