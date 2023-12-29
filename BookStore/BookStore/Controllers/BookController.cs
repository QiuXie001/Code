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
            List<DBLibrary.Books> list = DBLibrary.bill.Book.GetBooks();
            return View(list);
        }
    }
}