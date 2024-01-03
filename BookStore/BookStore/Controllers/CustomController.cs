using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class CustomController : Controller
    {
        // GET: Custom
        [HttpPost]
        public ActionResult InsertShopCart(int id)
        {
            Session["ShopCart_BookID"] = id;
            return RedirectToAction("BookList","Book");
        }
    }
}