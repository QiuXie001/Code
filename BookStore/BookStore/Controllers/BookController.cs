using DBLibrary;
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
            var type = DBLibrary.bill.Book.GetTypes();
            ViewBag.types = type;
            if (Session["search"].ToString() == "true")
            {
                return View(TempData["list"]);
            }
            List<DBLibrary.Books> list = DBLibrary.bill.Book.GetBooks();
            Session["search"] = "false";
            return View(list);
        }
        [HttpPost]
        public ActionResult BookList(string str)
        {
            var books = DBLibrary.bill.Book.SearchBooks(str);
            var type = DBLibrary.bill.Book.GetTypes();
            ViewBag.types = type;
            return View(books);
        }
        public ActionResult BookManage()
        {
            if (Session["search"].ToString() == "true")
            {
                return View(TempData["list"]);
            }
            List<DBLibrary.Books> list = DBLibrary.bill.Book.GetBooks();
            return View(list);
        }
        public ActionResult BookSearch(int Book_ID, string Title)
        {
            List<Books> list = DBLibrary.bill.Book.Search(Book_ID, Title);
            Session["search"] = "true";
            TempData["list"] = list;
            return RedirectToAction("BookManage", "Book");

        }
        public ActionResult BookSelect(string BookType)
        {
            List<Books> list = DBLibrary.bill.Book.SelectBooks(BookType);
            Session["search"] = "true";
            TempData["list"] = list;
            return RedirectToAction("BookList", "Book");
        }
        // GET: Admin
        public ActionResult BookUpdateView(int id)
        {
            TempData["bookid"] =id;
            var books = DBLibrary.bill.Book.GetBooks(id);
            return View(books);
        }

        [HttpPost]
        public ActionResult BookUpdate(Books books)
        {
            DBLibrary.bill.Book.Update(books,int.Parse(TempData["bookid"].ToString()));
            return RedirectToAction("BookManage", "Book");
        }
        public ActionResult BookAddView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BookAdd(Books books)
        {
            DBLibrary.bill.Book.Regist(books);
            return RedirectToAction("BookManage", "Book");
        }
        public ActionResult BookDelete(int id)
        {
            DBLibrary.bill.Book.Delete(id);
            return RedirectToAction("BookManage", "Book");
        }
        public ActionResult BookDetail(int id)
        {
            string title = null;
            var list = DBLibrary.bill.Book.Search(id, title);
            DBLibrary.Books book = new DBLibrary.Books();
            foreach (var i in list)
            {
                book = i;  
            }
            return View(book);
        }
    }
}