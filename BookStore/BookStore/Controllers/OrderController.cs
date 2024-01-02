using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult OrderManage()
        {
            if (Session["search"].ToString() == "false")
            {
                var entry = DBLibrary.bill.Order.GetAllOrder(int.Parse(Session["Info"].ToString()));
                return View(entry);
            }
            Session["search"] = "false";
            return View(TempData["list"]);
        }
        public ActionResult OrderSearch(int OrderID, string Address)
        {
            List<DBLibrary.Orders> list = DBLibrary.bill.Order.Search(OrderID, Address);
            Session["search"] = "true";
            TempData["list"] = list;
            return RedirectToAction("OrderManage", "Order");
        }
    }
}