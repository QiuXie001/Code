using DBLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult CustomSearch(int Custom_ID,string Custom_Telephone)
        {
            List<DBLibrary.Custom> list = DBLibrary.bill.Custom.Search( Custom_ID, Custom_Telephone);
            Session["search"] = "true";
            TempData["list"] = list;
            return RedirectToAction("CustomUserManage", "Admin");
            
        }
        // GET: Admin
        public ActionResult CustomUserManage()
        {
            if (Session["search"].ToString() == "false")
            {
                var entry = DBLibrary.bill.Custom.GetAllCustom();
                return View(entry);
            }
            Session["search"] = "false";
            return View(TempData["list"]);
        }
        public ActionResult CustomUpdateView(int id)
        { 
            var custom = DBLibrary.bill.Custom.GetCustom(id);
            return View(custom);
        }

        [HttpPost]
        public ActionResult CustomUpdate(Custom custom) 
        {
            DBLibrary.bill.Custom.Update(custom);
                return RedirectToAction("CustomUserManage", "Admin");
        }
        public ActionResult AdminUpdateView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminUpdate(Admin admin)
        {
            DBLibrary.bill.Admin.Update(admin);
                return RedirectToAction("AdminUserManage", "Admin");

        }
        public ActionResult AdminSearch(int Admin_ID, string Admin_Telephone)
        {
            List<DBLibrary.Admin> list = DBLibrary.bill.Admin.Search(Admin_ID, Admin_Telephone);
            Session["search"] = "true";
            TempData["list"] = list;
            return RedirectToAction("AdminUserManage", "Admin");
        }
        public ActionResult AdminUserManage(List<Admin> data)
        {
            List<Admin> list = data;
            if (Session["search"].ToString() == "false")
            {
                var entry = DBLibrary.bill.Admin.GetAllAdmin();
                return View(entry);
            }
            Session["search"] = "false";
            return View(TempData["list"]);
        }

        public ActionResult CustomAddView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomAdd(Custom custom)
        {
            DBLibrary.bill.Custom.regist(custom);
            return RedirectToAction("CustomUserManage", "Admin");
        }
        public ActionResult AdminAddView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(Admin admin)
        {
            DBLibrary.bill.Admin.regist(admin);
            return RedirectToAction("AdminUserManage", "Admin");
        }
        public ActionResult CustomDelete(int id) 
        {
            DBLibrary.bill.Custom.Delete(id);
            return RedirectToAction("CustomUserManage", "Admin"); 
        }
        public ActionResult AdminDelete(int id)
        {
            DBLibrary.bill.Admin.Delete(id);
            return RedirectToAction("AdminUserManage", "Admin");
        }
    }
}