using DBLibrary;
using DBLibrary.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class PersonalInformationController : BaseController
    {
        // GET: PersonalInformation
        public ActionResult CustomInformation()
        {
            var i =int.Parse(Session["Info"].ToString());
            Custom info = CustomService.GetCustom(int.Parse(Session["Info"].ToString()));
            return View(info);
        }
        [HttpPost]
        public ActionResult CustomInformation(Custom entry)
        {
            if (Request.Files.Count > 0 && Request.Files[0].FileName != "")
            {
                var filename = DateTime.Now.Ticks;
                string savepath = Server.MapPath("~/uploads/") + filename + ".jpg";
                Request.Files[0].SaveAs(savepath);
                TempData["img"] = "/uploads/" + filename + ".jpg";
                entry.Id = int.Parse(Session["info"].ToString());
                entry.HeadShotUrl = TempData["img"].ToString();
            }
            CustomService.Update(entry);
            return Content("<script>alert('修改成功!');window.location.href = '../PersonalInformation/CustomInformation';</script>");
        }
        public ActionResult AdminInformation()
        {
            DBLibrary.Admin info = AdminService.GetAdmin(int.Parse(Session["Info"].ToString()));
            return View(info);
        }
        [HttpPost]
        public ActionResult AdminInformation(Admin entry)
        {
            if (Request.Files.Count > 0 && Request.Files[0].FileName != "")
            {
                var filename = DateTime.Now.Ticks;
                string savepath = Server.MapPath("~/uploads/") +filename+ ".jpg";
                Request.Files[0].SaveAs(savepath);
                TempData["img"] = "/uploads/" + filename+ ".jpg";
                entry.Id = int.Parse(Session["info"].ToString());
                entry.HeadShotUrl = TempData["img"].ToString();
            }
            AdminService.Update(entry);
            return Content("<script>alert('修改成功!');window.location.href = '../PersonalInformation/AdminInformation';</script>");
        }
    }
}