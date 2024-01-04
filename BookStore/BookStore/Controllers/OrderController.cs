using DBLibrary.bill;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Order
        public ActionResult OrderManage()
        {
            if (Session["search"].ToString() == "false" && Session["identity"].ToString() != "admin")
            {
                var entry = DBLibrary.bill.Order.GetOrder(int.Parse(Session["Info"].ToString()));
                return View(entry);
            }
            else if(Session["search"].ToString() == "false")
            {
                var entry = DBLibrary.bill.Order.GetAllOrder(int.Parse(Session["Info"].ToString()));
                return View(entry);
            }
            Session["search"] = "false";
            return View(TempData["list"]);
        }
        public ActionResult OrderSearch(int? OrderID, string OrderTelephone)
        {
            if(OrderID==null)OrderID = 0;
            if (Session["identity"].ToString() != "admin")
            {
                List<DBLibrary.Orders> list = DBLibrary.bill.Order.Search(OrderID, OrderTelephone, int.Parse(Session["Info"].ToString()));
                Session["search"] = "true";
                TempData["list"] = list;
                return RedirectToAction("OrderManage", "Order");
            }
            else 
            {
                List<DBLibrary.Orders> list = DBLibrary.bill.Order.Search(OrderID, OrderTelephone);
                Session["search"] = "true";
                TempData["list"] = list;
                return RedirectToAction("OrderManage", "Order");
            }
            
        }
        public ActionResult OrderSubmit()
        {
            if (Session["Orders"] != null) 
            {
                List<DBLibrary.Orders> orders = (List<DBLibrary.Orders>)Session["Orders"];
                return View(orders);
            }
            return View();
        }
        [HttpGet]
        public ActionResult OrderSubmitMultiple()
        {

            return View();
        }
        [HttpPost]
        public ActionResult OrderSubmitMultiple(List<DBLibrary.Orders> orders)
        {
            Session["Orders"] = orders;
            return RedirectToAction("OrderSubmit", "Order", orders);
        }
        [HttpPost]
        public ActionResult OrderSubmit(int bookid ,int num)
        {
            DBLibrary.Books book = Book.GetBooks(bookid);
            DBLibrary.Orders order = new DBLibrary.Orders();
            order.BookID = bookid.ToString();
            order.Num = num;
            order.Price = book.Price;
            List<DBLibrary.Orders> list = new List<DBLibrary.Orders>();
            list.Add(order);
            return View(list);
        }
        [HttpPost]
        public ActionResult OrderSave(List<DBLibrary.Orders>orders)
        {
            Session["price"] = 0;
            long OrderID = long.Parse(DateTime.Now.Ticks.ToString()); ;
            DateTime OrderTime = DateTime.Now;
            foreach (var i in orders)
            {
                i.CustomID = int.Parse(Session["info"].ToString());
                i.OrderID = OrderID;
                i.OrderTime = OrderTime;
                Session["price"] = decimal.Parse(Session["price"].ToString()) + (i.Price * i.Num);
                i.Price *= i.Num;
                i.ClearOrNot = false;
                i.ReceiptOrNot = false;
            }
            foreach (var i in orders)
            {
                Debug.WriteLine(decimal.Parse(Session["price"].ToString()));
                i.Price = decimal.Parse(Session["price"].ToString());
            }
            DBLibrary.bill.Order.InsertOrder(orders);
            return RedirectToAction("OrderManage", "Order");
        }
        public ActionResult Delete(long id)
        {
            Order.Delete(id);
            return RedirectToAction("OrderManage", "Order");
        }
        public ActionResult Clear(long id)
        {
            Order.Clear(id);
            return RedirectToAction("OrderManage", "Order");
        }
        public ActionResult Receipt(long id)
        {
            Order.Receipt(id);
            return RedirectToAction("OrderManage", "Order");
        }

    }
}