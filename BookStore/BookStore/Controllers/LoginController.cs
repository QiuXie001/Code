using DBLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{

    public class LoginController : BaseController
    {
        [HttpGet]
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string ID, string password)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            if (ID.Substring(0, 1) == "a")
            {
                Admin admin = db.Admin.SingleOrDefault(a => a.Admin_IdentityID == ID);
                password = password.PadRight(10, ' ');
                //if (account.Password == password)
                //    Debug.WriteLine("通过");
                if (admin != null && admin.Admin_Password == password)
                {
                    Session["isLogin"] = true;
                    Response.ClearContent();
                    return RedirectToAction("List", "Book");
                }
                else
                {
                    return View();

                }
            }
            else
            {
                Admin admin = db.Admin.SingleOrDefault(a => a.Admin_IdentityID == ID);
                password = password.PadRight(10, ' ');
                //if (account.Password == password)
                //    Debug.WriteLine("通过");
                if (admin != null && admin.Admin_Password == password)
                {
                    Session["isLogin"] = true;
                    Response.ClearContent();
                    return RedirectToAction("List", "Book");
                }
                else
                {
                    return View();

                }


            }
        }
    }
}