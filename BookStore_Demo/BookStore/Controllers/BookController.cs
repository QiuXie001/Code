using DBLibrary;
using DBLibrary.Bll;
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
            var type = BookService.GetTypes();
            ViewBag.types = type;
            if (Session["search"].ToString() == "true")
            {

                Session["search"] = "false";
                return View(TempData["list"]);
            }
            List<DBLibrary.Book> list = BookService.GetBooks();
            Session["search"] = "false";
            return View(list);
        }

        // GET: Book
        [HttpGet]
        public JsonResult SearchBookList(string typeName)
        {
            var bookList = BookService.SelectBooks(typeName);
            return Json(bookList,JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult BookList(string str)
        {
            var books = BookService.SearchBooks(str);
            var type = BookService.GetTypes();
            ViewBag.types = type;
            return View(books);
        }
        public ActionResult BookManage()
        {
            if (Session["search"].ToString() == "true")
            {
                return View(TempData["list"]);
            }
            List<DBLibrary.Book> list = BookService.GetBooks();
            return View(list);
        }
        public ActionResult BookSearch(int Book_ID, string Title)
        {
            List<Book> list = BookService.Search(Book_ID, Title);
            Session["search"] = "true";
            TempData["list"] = list;
            return RedirectToAction("BookManage", "Book");

        }
        public ActionResult BookSelect(string BookType)
        {
            List<Book> list = BookService.SelectBooks(BookType);
            Session["search"] = "true";
            TempData["list"] = list;
            return RedirectToAction("BookList", "Book");
        }
        // GET: Admin
        public ActionResult BookUpdateView(int id)
        {
            TempData["bookid"] =id;
            var books = BookService.GetBooks(id);
            return View(books);
        }

        [HttpPost]
        public ActionResult BookUpdate(Book books)
        {
            BookService.Update(books,int.Parse(TempData["bookid"].ToString()));
            return RedirectToAction("BookManage", "Book");
        }
        public ActionResult BookAddView()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BookAdd(Book books)
        {
            BookService.Regist(books);
            return RedirectToAction("BookManage", "Book");
        }
        public ActionResult BookDelete(int id)
        {
            BookService.Delete(id);
            return RedirectToAction("BookManage", "Book");
        }
        public ActionResult BookDetail(int id)
        {
            string title = null;
            var list = BookService.Search(id, title);
            DBLibrary.Book book = new DBLibrary.Book();
            foreach (var i in list)
            {
                book = i;  
            }
            return View(book);
        }
    }
}