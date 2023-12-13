using System;
using store.Uitl.Filters;
using System.Linq;
using System.Web.Mvc;
using db;
using db.bill;
using System.Diagnostics;
using System.Data.Entity.Validation;


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
        public ActionResult Login(int UserID,string password) 
        {
            mvcStudyEntities db = new mvcStudyEntities();
            db.Account account = db.Accounts.SingleOrDefault(a => a.UserID == UserID);
            password = password.PadRight( 10, ' ' );
            //if (account.Password == password)
            //    Debug.WriteLine("通过");
            if (account!=null&&account.Password == password)
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
        [HttpGet]
        public ActionResult Regist()
        {
            db.Account entry = new db.Account();    
            return View(entry);
        }
        [HttpPost]
        public ActionResult Regist(db.Account entry)
        {
            
            if (Request.Files.Count > 0 && Request.Files[0].FileName != "")
            {
                string savepath = Server.MapPath("~/upload/") + Request.Files[0].FileName;
                Request.Files[0].SaveAs(savepath);
                TempData["img"] = "/upload/"+ Request.Files[0].FileName;
            }
            if (ModelState.IsValid)
            {
                TempData["userName"] = entry.Password;
                TempData["age"] = entry.Age;
                TempData["email"] = entry.Email;
                TempData["identityID"] = entry.identityID;
                TempData["telephone"] = entry.telephone;
                return RedirectToAction("UserInfo");
            }
            return View(entry);
        }
        public ActionResult UserInfo() 
        {
            
            return View();
        }
    }
}
