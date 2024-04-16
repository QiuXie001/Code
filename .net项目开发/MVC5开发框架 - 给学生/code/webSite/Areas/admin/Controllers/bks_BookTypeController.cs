using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Controllers;

namespace web.Areas.admin.Controllers
{
    public class bks_BookTypeController : baseController
    {
        /// <summary>
        /// 主界面的查询Action
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Select(db.view.bks_BookType model)
        {
            model.Search();
            //ajax请求是返回局部视图
            if (Request.IsAjaxRequest())
                return PartialView("_showData", model);
            return View(model);
        }

        ////
        //// GET: /admin/bks_BookType/
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public JsonResult batchSave()
        {
            JsonResult result = new JsonResult();
            try
            {
                //获取界面数据
                List<string> bookTypeCodeList = rui.requestHelper.getList("detail.bookTypeCode");
                List<string> showOrderList = rui.requestHelper.getList("detail.showOrder");
                //将获取数据传给业务类
                string msg = db.bll.bks_bookType.batchSave(showOrderList, bookTypeCodeList, dc);
                result.Data = rui.jsonResult.getAJAXResult(msg, true);
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                result.Data = rui.jsonResult.getAJAXResult(rui.excptHelper.getExMsg(ex), false);
            }
            return result;
        }
    }
}