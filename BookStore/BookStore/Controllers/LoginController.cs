using DBLibrary;
using DBLibrary.bill;
using System.Linq;
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
        public ActionResult Login(string ID, string Password)
        {
            mvcStudyEntities db = new mvcStudyEntities();
            Password = Password.PadRight(10,' ');
            if (ID.Substring(0, 1) == "1")
            {
                DBLibrary.Admin admin = db.Admin.SingleOrDefault(a => a.Admin_ID.ToString() == ID);
                //if (account.Password == password)
                //    Debug.WriteLine("通过");
                if (admin != null && admin.Admin_Password == Password)
                {
                    Session["isLogin"] = true;
                    Session["identity"] = "admin";
                    Session["Info"] = admin.Admin_ID;
                    Response.ClearContent();
                    return RedirectToAction("MainBoard", "Main");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                DBLibrary.Custom custom = db.Custom.SingleOrDefault(a => a.Custom_ID.ToString() == ID);
                //if (account.Password == password)
                //    Debug.WriteLine("通过");
                if (custom != null && custom.Custom_Password == Password)
                {
                    Session["isLogin"] = true;
                    Session["identity"] = "custom";
                    Session["Info"] = custom.Custom_ID;
                    return RedirectToAction("MainBoard", "Main");
                }
                else
                {
                    return View();
                }
            }
        }
        [HttpPost]
        public ActionResult Regist(DBLibrary.Custom entry)
        {
            if (Request.Files.Count > 0 && Request.Files[0].FileName != "")
            {
                string savepath = Server.MapPath("~/upload/") + Request.Files[0].FileName;
                Request.Files[0].SaveAs(savepath);
                TempData["img"] = "/upload/" + Request.Files[0].FileName;
            }
            if (ModelState.IsValid)
            {
                TempData["Name"] = entry.Custom_Name;
                TempData["Password"] = entry.Custom_Password;
                TempData["Telephone"] = entry.Custom_Telephone;
                DBLibrary.bill.Custom.regist(entry);
                Session["isLogin"] = true;
                TempData["identity"] = "custom";
                TempData["Info"] = entry.Custom_ID;
                return RedirectToAction("MainBoard", "Main");
            }
            return View("Login"); 
        }
    }
}