using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Controllers;

namespace web.Areas.admin.Controllers
{
    public class bks_BookController : baseController
    {
        // GET: admin/bks_Book
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select(db.view.bks_Book model)
        {
            model.Search();

            if (Request.IsAjaxRequest())
            { 
                   return PartialView("_showData",model);
            }

            return View(model);
        }
    }
}