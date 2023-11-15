using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db;
using store.Controllers;
using store.Uitl.Filters;

namespace store.Controllers
{
    public class zsgController : BaseController
    {
        //
        // GET: /zsg/


        //图书新增
        [HttpGet]
        public ActionResult insert1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insert1(db.Books books)
        {
            db.bill.Book.insert1(books);
            return RedirectToAction("List", "Book");
        }
        [HttpGet]
        public ActionResult insert2()
        {
            return View();
        }
        [HttpPost]
        public ActionResult insert2(string bookname, string title, Nullable<decimal> Price)
        {
            db.bill.Book.insert2(bookname, title, Price);
            return RedirectToAction("List", "Book");
        }
        
        //图书修改
        [HttpGet]
        public ActionResult update1(int bookid)
        {
            db.Books books= db.bill.Book.GetEntry(bookid);
            return View(books);
        }
        [HttpPost]
        public ActionResult update1(db.Books books)
        {
            db.bill.Book.update1(books);
            return RedirectToAction("List", "Book");
        }

        [HttpGet]
        public ActionResult update2(int bookid)
        {
            db.Books books = db.bill.Book.GetEntry(bookid);
            return View(books);
        }
        [HttpPost]
        public ActionResult update2(db.Books books)
        {
            db.bill.Book.update2(books);
            return RedirectToAction("List", "Book");
        }

        [HttpGet]
        public ActionResult update3(int bookid)
        {
            db.Books books = db.bill.Book.GetEntry(bookid);
            return View(books);
        }
        [HttpPost]
        public ActionResult update3(int bookid,string AuthorName, string title, Nullable<decimal> Price)
        {
            db.bill.Book.update3(bookid , AuthorName, title, Price);
            return RedirectToAction("List", "Book");
        }

        public ActionResult delete(int bookid)
        {
            db.bill.Book.delete(bookid);
            return RedirectToAction("List", "Book");
        }
        public ActionResult detail(int bookid)
        {
            db.Books entry = db.bill.Book.GetEntry(bookid);
            return View(entry);
        }
    }
}
