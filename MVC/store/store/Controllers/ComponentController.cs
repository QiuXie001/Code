using Antlr.Runtime;
using db.meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml.Linq;

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
        public ActionResult leaveMessage(string userName, string message)
        {
            var file = Request.Files;
            string result = string.Format("<div>用户：{0},留言内容:{1}</div>",
                userName, message);
            var json = new { message = result};
            return View();
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
        public ActionResult JsonTest()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult JsonTest(string name)
        {
            // 创建顶层对象
            var person = new db.meta.Person
            {
                Name = "SomeName",
                Parent = new List<db.meta.Parent>
            {
                new Parent { Name = "ParentName1", Age = 10 },
                new Parent { Name = "ParentName2", Age = 20 }
            }
            };

            // 返回JSON格式的数据
            return Json(person, JsonRequestBehavior.AllowGet);
        }
        public ActionResult indexValidate()
        {
            return View();
        }

    }
}
