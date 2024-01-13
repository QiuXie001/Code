using DBLibrary;
using DBLibrary.Bll;
using System.Data;
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
        public ActionResult Login(DBLibrary.Admin entry)
        {
            Session.RemoveAll();
            if (entry.Id!=0&&entry.Password!=null)
            {
                StoreContext db = new StoreContext();
                string Password = entry.Password.PadRight(10, ' ');
                if (entry.Password.Substring(0, 1) == "1")
                {
                    DBLibrary.Admin admin = db.Admins.SingleOrDefault(a => a.Id == entry.Id);
                    //if (account.Password == password)
                    //    Debug.WriteLine("通过");
                    if (admin != null && admin.Password == Password)
                    {
                        Session["isLogin"] = true;
                        Session["identity"] = "admin";
                        Session["Info"] = admin.Id;
                        Session["Operational"] = false;
                        Session["HeadShot"] = admin.HeadShotUrl;
                        Session["Name"] = admin.Name;
                        Response.ClearContent();
                        return RedirectToAction("MainBoard", "Main");
                    }
                    else
                    {
                        DBLibrary.Custom custom = db.Customs.SingleOrDefault(a => a.Id == entry.Id);
                        //if (account.Password == password)
                        //    Debug.WriteLine("通过");
                        if (custom != null && custom.Password == Password)
                        {
                            Session["isLogin"] = true;
                            Session["identity"] = "custom";
                            Session["Info"] = custom.Id;
                            Session["Operational"] = false;
                            Session["HeadShot"] = custom.HeadShotUrl;
                            Session["Name"] = custom.Name;
                            return RedirectToAction("MainBoard", "Main");
                        }
                        return Content(" <script>alert( '用户名或密码错误！' );" +
                            "window.location.href = '../../Login/Login'; </script> "); ;
                    }
                }
            }
            return View(entry);
        }
        [HttpPost]
        public ActionResult Regist(DBLibrary.Custom entry)
        {
            if (ModelState.IsValid)
            {
                Session["isLogin"] = true;
                Session["identity"] = "custom";
                Session["Info"] = entry.Id;
                Session["Operational"] = false;
                Session["HeadShot"] = entry.HeadShotUrl;
                Session["Name"] = entry.Name;
                CustomService.regist(entry);
                return RedirectToAction("MainBoard", "Main");
            }
            DBLibrary.Admin admin = new DBLibrary.Admin();
            return View("Login",admin); 
        }
    }
}