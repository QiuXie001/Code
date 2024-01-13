using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using BookStore.DBStandard;
using BookStore.DBStandard.Models;

namespace BookStore.Controllers;

public class MainController : Controller
{
    // GET: Main
    public ActionResult MainBoard()
    {
        return View();
    }

    public ActionResult BookList(string title)
    {
        var dbContext = new MvcStudyContext();
        List<Book> books = new List<Book>();
        ViewBag.Data = title;
        return PartialView("~/Views/Book/BookList.cshtml", books); ;
    }


}
