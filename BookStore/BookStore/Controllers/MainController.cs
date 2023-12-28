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
            return View();
        }

        public ActionResult BookList(string title)
        {
            List<Books> book = new List<Books>();
            ViewBag.Data = title;
            return PartialView("~/Views/Book/BookList.cshtml", book); ;
        }
    }
}