using DBLibrary.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class CustomController : BaseController
    {
        // GET: Custom
        [HttpPost]
        public ActionResult InsertShopCart(int id)
        {
            var book = BookService.GetBooks(id);
            List<DBLibrary.Book> list = new List<DBLibrary.Book>(); 
            if (Session["ShopCart_Book"] != null)
            {
                list = (List<DBLibrary.Book>)Session["ShopCart_Book"];
            }
            if (!list.Any(b => b.Id == book.Id))
            {
                list.Add(book);
            }
            Session["ShopCart_Book"] = list;
            return RedirectToAction("BookList","Book");
        }
        public ActionResult ShopCart()
        {
            
            return View((List<DBLibrary.Book>)Session["ShopCart_Book"]);
        }
        public ActionResult DeleteShopCart(int id)
        {
            var book = BookService.GetBooks(id);
            List<DBLibrary.Book> list = new List<DBLibrary.Book>();
            if (Session["ShopCart_Book"] != null)
            {
                list = (List<DBLibrary.Book>)Session["ShopCart_Book"];
            }
            if (list.Any(b => b.Id == book.Id))
            {
                list.Remove(list.FirstOrDefault(b => b.Id == book.Id)) ;
            }
            Session["ShopCart_Book"] = list;
            return RedirectToAction("ShopCart", "Custom");
        }
    }
}