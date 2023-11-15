using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db;
using store.Uitl.Filters;

namespace store.Controllers
{
    public class BookController : BaseController
    {
        //
        // GET: /Book/

        public ActionResult Index()
        {
            return View();
        }
        //[OutputCache(CacheProfile = "cache")]
        public ActionResult List()
        {
            string Timing = TimingActionFilter.Timing;
            ViewData["Timing"] = Timing;
            ViewBag.Timing = Timing;
            List<db.Books> list = db.bill.Book.GetBooks();
            return View(list);
        }
        public ActionResult OrderList()
        {
            List<db.Detail> list = db.bill.Book.GetDetail();
            return View(list);
        }
        [HttpGet]
        public ActionResult Order(int bookid)
        {
            db.Books entry = db.bill.Book.GetEntry(bookid);
            return View(entry);
        }
        [HttpPost]
        public ActionResult Order(int bookID,int num,string address)
        {
            db.bill.Order.insert(bookID,num,address);
            return RedirectToAction("OrderList");
        }
        public ActionResult test()
        {
            int x = 2, y = 0;
            x = x / y;
            ViewBag.x = x;
            return View();
        }
    }
}
