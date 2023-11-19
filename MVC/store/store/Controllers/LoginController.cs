using db.bill;
using store.Uitl.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Data.Entity;
using System.Web.Configuration;
using db;
using System.Diagnostics;
using System.Data.Metadata.Edm;

namespace store.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /login/


        [HttpGet]
        [OutputCache(Duration = 10)]
        public ActionResult Login()
        {
            string Timing = TimingActionFilter.Timing;
            ViewData["Timing"] = Timing;
            ViewBag.Timing = Timing;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username,string password) 
        {
            mvcStudyEntities db = new mvcStudyEntities();
            Account account = db.Accounts.SingleOrDefault(a => a.Username == username ) ;
            password = password.PadRight( 10, ' ' );
            //if (account.Password == password)
            //    Debug.WriteLine("通过");
            if (account.Password == password)
            {
                Session["isLogin"] = true;
                ClearTempData();
                Response.ClearContent();
                return RedirectToAction("List", "Book");
            }
            else
            {

                return Content(
      @"<div class='error'>  
           <h2>登录失败</h2>  
           <p>请检查您的用户名和密码是否正确。</p >  
             
      </ div > ",

      "text/html");
            }
        }
        
        public void ClearTempData()
        {
            if (TempData.Count > 0)
            {
                TempData.Clear();
            }
        }
        public ActionResult Regist()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Regist(string username, string password, string age, string city, string[] hobby, db.Account entry)
        {
            
            if (Request.Files.Count > 0 && Request.Files[0].FileName != "")
            {
                string savepath = Server.MapPath("~/upload/") + Request.Files[0].FileName;
                Request.Files[0].SaveAs(savepath);
                TempData["img"] = "/upload/"+ Request.Files[0].FileName;
            }
            
            TempData["username"] = username;
            TempData["password"] = password;
            TempData["age"] = age;
            TempData["city"] = city;
            for (int i = 0; i < hobby.Length; i++)
                TempData["hobby"] += hobby[i];
            if (username != "admin")
            {
                mvcStudyEntities db = new mvcStudyEntities();

                db.Accounts.Add(entry);
                db.SaveChanges();
            }

            return Redirect("UserInfo");
        }
        public ActionResult UserInfo() 
        {
            
            return View();
        }
    }
}
