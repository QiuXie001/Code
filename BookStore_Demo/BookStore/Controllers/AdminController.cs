using DBLibrary;
using DBLibrary.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class AdminController : BaseController
    {
        public ActionResult CustomSearch(int Id,string Custom_Telephone)
        {
            List<DBLibrary.Custom> list = CustomService.Search( Id, Custom_Telephone);
            Session["search"] = "true";
            TempData["list"] = list;
            return RedirectToAction("CustomUserManage", "Admin");
            
        }
        // GET: Admin
        public ActionResult CustomUserManage()
        {
            if (Session["search"].ToString() == "false")
            {
                var entry = CustomService.GetAllCustom();
                return View(entry);
            }
            Session["search"] = "false";
            return View(TempData["list"]);
        }
        public ActionResult CustomUpdateView(int id)
        { 
            var custom = CustomService.GetCustom(id);
            Session["Id"] = id;
            return View(custom);
        }

        [HttpPost]
        public ActionResult CustomUpdate(DBLibrary.Custom custom) 
        {
            custom.Id = int.Parse(Session["Id"].ToString());
            CustomService.Update(custom);
                return RedirectToAction("CustomUserManage", "Admin");
        }
        public ActionResult AdminUpdateView(int id)
        {
            var admin = AdminService.GetAdmin(id);
            Session["Id"] = id;
            return View(admin);
        }
        [HttpPost]
        public ActionResult AdminUpdate(DBLibrary.Admin admin)
        {
            admin.Id = int.Parse(Session["Id"].ToString());
            AdminService.Update(admin);
            return RedirectToAction("AdminUserManage", "Admin");

        }
        public ActionResult AdminSearch(int Id, string Admin_Telephone)
        {
            List<DBLibrary.Admin> list = AdminService.Search(Id, Admin_Telephone);
            Session["search"] = "true";
            TempData["list"] = list;
            return RedirectToAction("AdminUserManage", "Admin");
        }
        public ActionResult AdminUserManage(List<DBLibrary.Admin> data)
        {
            List<DBLibrary.Admin> list = data;
            if (Session["search"].ToString() == "false")
            {
                var entry = AdminService.GetAllAdmin();
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
        public ActionResult CustomAdd(DBLibrary.Custom custom)
        {
            CustomService.regist(custom);
            return RedirectToAction("CustomUserManage", "Admin");
        }
        public ActionResult AdminAddView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminAdd(DBLibrary.Admin admin)
        {
            AdminService.regist(admin);
            return RedirectToAction("AdminUserManage", "Admin");
        }
        public ActionResult CustomDelete(int id) 
        {
            CustomService.Delete(id);
            return RedirectToAction("CustomUserManage", "Admin"); 
        }
        public ActionResult AdminDelete(int id)
        {
            AdminService.Delete(id);
            return RedirectToAction("AdminUserManage", "Admin");
        }
    }
}