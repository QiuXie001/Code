using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace store.Controllers
{
    public class ComponentController : Controller
    {
        //
        // GET: /Component/
        [HttpGet]
        public ActionResult MessageBoard()
        {
            return View();
        }
        [HttpPost]
        public string MessageBoard(FormCollection collection)
        {
            return AddMessage(collection["ytitle"], collection["ycontent"], collection["yemail"], collection["yqq"]);
        }
        public string AddMessage(string ytitle,string ycontent,string yemail,string yqq)
        {
            Thread.Sleep(2000);
            string kmessage = "标题："+ytitle+"Email："+yemail+"QQ："+yqq+"内容："+ycontent+"</br>";
            return kmessage;
        }
        [HttpGet]
        public ActionResult Message()
        {
            Thread.Sleep(2000);
            ViewBag.Message = ("Ajax测试");
            return PartialView("Message");
        }
        public JsonResult leaveMessageAjax(string userName, string message)
        {
            var file = Request.Files;
            string result = string.Format("<div>用户：{0},留言内容:{1}</div>",
                userName, message);
            var json = new { message = result };
            Thread.Sleep(2000);
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult jsonTest()
        {

            return View();
        }
        //[HttpPost]
        //public ActionResult jsonTest()
        //{
        //    return Json();
        //}

    }
}
