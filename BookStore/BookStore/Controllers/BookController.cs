using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookController : BaseController
    {
        // GET: Book
        public ActionResult BookList()
        {
            return View();
        }
    }
}