using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookStore.DBStandard;
using BookStore.Domain;
using System.Web;
using BookStore.DBStandard.Models;
using BookStore.Domain.Service;


namespace BookStore.Controllers;

public class BookController : Controller
{
    public ActionResult BookList()
        {
            var dbContext = new MvcStudyContext();
            var bookService = new BookService(dbContext);
            var list = bookService.GetBooks();
            return View(list);
        }
}