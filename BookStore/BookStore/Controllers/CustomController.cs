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
            var book = DBLibrary.bill.Book.GetBooks(id);
            List<DBLibrary.Books> list = new List<DBLibrary.Books>(); 
            if (Session["ShopCart_Book"] != null)
            {
                list = (List<DBLibrary.Books>)Session["ShopCart_Book"];
            }
            if (!list.Any(b => b.Book_ID == book.Book_ID))
            {
                list.Add(book);
            }
            Session["ShopCart_Book"] = list;
            return RedirectToAction("BookList","Book");
        }
        public ActionResult ShopCart()
        {
            
            return View((List<DBLibrary.Books>)Session["ShopCart_Book"]);
        }
        public ActionResult DeleteShopCart(int id)
        {
            var book = DBLibrary.bill.Book.GetBooks(id);
            List<DBLibrary.Books> list = new List<DBLibrary.Books>();
            if (Session["ShopCart_Book"] != null)
            {
                list = (List<DBLibrary.Books>)Session["ShopCart_Book"];
            }
            if (list.Any(b => b.Book_ID == book.Book_ID))
            {
                list.Remove(list.FirstOrDefault(b => b.Book_ID == book.Book_ID)) ;
            }
            Session["ShopCart_Book"] = list;
            return RedirectToAction("ShopCart", "Custom");
        }
    }
}