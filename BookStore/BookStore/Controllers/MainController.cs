using DBLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class MainController : BaseController
    {

        // GET: Main
        public ActionResult MainBoard()
        {
            Session["search"] = "false";
            return View();
        }

    }
}