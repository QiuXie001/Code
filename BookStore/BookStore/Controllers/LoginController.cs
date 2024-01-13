using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using BookStore.DBStandard.Models;

namespace BookStore.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string ID, string Password)
        {
            MvcStudyContext db = new MvcStudyContext();
            if (ID[..1] == "1")
            {
                Admin admin = db.Admins.SingleOrDefault(a => a.AdminId.ToString() == ID);
                //if (account.Password == password)
                //    Debug.WriteLine("通过");
                if (admin != null && admin.AdminPassword == Password)
                {
                    HttpContext.Session.SetString("isLogin", "true");
                    Response.Clear();
                    return RedirectToAction("MainBoard", "Main");
                }
                else
                {
                    TempData["identity"] = "manager";
                    return View();
                }
            }
            else
            {
                Custom custom = db.Customs.SingleOrDefault(a => a.CustomId.ToString() == ID);
                //if (account.Password == password)
                //    Debug.WriteLine("通过");
                if (custom != null && custom.CustomPassword == Password)
                {
                    HttpContext.Session.SetString("isLogin", "true");
                    Response.Clear();
                    return View("MainBoard", "Main");
                }
                else
                {
                    TempData["identity"] = "custom";
                    return View();
                }
            }
        }
        [HttpPost]
        public ActionResult Regist(Custom entry)
        {
            if (ModelState.IsValid)
            {
                var dbContext = new MvcStudyContext();
                var customService = new BookStore.Domain.Service.CustomService(dbContext);

                TempData["Name"] = entry.CustomName;
                TempData["Password"] = entry.CustomPassword;
                TempData["Telephone"] = entry.CustomTelephone;

                customService.Register(entry);
                HttpContext.Session.SetString("isLogin", "true");
                return RedirectToAction("MainBoard", "Main");
            }
            return View("Login");
        }
    }
}
