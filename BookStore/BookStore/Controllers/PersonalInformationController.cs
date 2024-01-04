using DBLibrary;
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
            Custom info = DBLibrary.bill.Custom.GetCustom(int.Parse(Session["Info"].ToString()));
            return View(info);
        }
        [HttpPost]
        public ActionResult CustomInformation(Custom entry)
        {
            DBLibrary.bill.Custom.Update(entry);
            return Content("<script>alert('修改成功!');window.location.href = '../PersonalInformation/CustomInformation';</script>");
        }
        public ActionResult AdminInformation()
        {
            DBLibrary.Admin info = DBLibrary.bill.Admin.GetAdmin(int.Parse(Session["Info"].ToString()));
            return View(info);
        }
        [HttpPost]
        public ActionResult AdminInformation(Admin entry)
        {
            DBLibrary.bill.Admin.Update(entry);
            return Content("<script>alert('修改成功!');window.location.href = '../PersonalInformation/AdminInformation';</script>");
        }
    }
}