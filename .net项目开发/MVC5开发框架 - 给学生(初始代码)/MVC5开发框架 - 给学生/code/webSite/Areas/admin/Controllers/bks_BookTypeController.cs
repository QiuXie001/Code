using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Areas.admin.Controllers
{
    public class bks_BookTypeController : Controller
    {
        // GET: admin/bks_BookType
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Select(db.view.bks_BookType model)
        {
            model.Search();

            if (Request.IsAjaxRequest())
            {
                return PartialView("_showData", model);
            }

            return View(model);
        }
    }
}