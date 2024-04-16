using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Controllers;
using db.bll;

namespace web.Areas.admin.Controllers
{
    public class bks_BookController : baseController
    {
        /// <summary>
        /// 主界面的查询Action
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Select(db.view.bks_Book model)
        {
            model.Search();
            //ajax请求是返回局部视图
            if (Request.IsAjaxRequest())
                return PartialView("_showData", model);
            return View(model);
        }
        //上架
        [HttpPost]
        public JsonResult Sell(string bookCode)
        {
            rui.jsonResult result = new rui.jsonResult();
            try
            {
                string msg = db.bll.bks_book.Sell(bookCode, dc);
                result.data = rui.jsonResult.getAJAXResult(msg, true);
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                result.data = rui.jsonResult.getAJAXResult(ex.Message, false);
            }
            return Json(result.data);
        }


        //下架
        [HttpPost]
        public JsonResult NoSell(string bookCode)
        {
            rui.jsonResult result = new rui.jsonResult();
            try
            {
                string msg = db.bll.bks_book.NoSell(bookCode, dc);
                result.data = rui.jsonResult.getAJAXResult(msg, true);
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                result.data = rui.jsonResult.getAJAXResult(ex.Message, false);
            }
            return Json(result.data);
        }
        ////
        //// GET: /admin/bks_Book/
        //public ActionResult Index()
        //{
        //    return View();
        //}
        //批量保存
        public JsonResult batchSave()
        {
            JsonResult result = new JsonResult();
            try
            {
                //获取界面数据
                List<string> bookCodeList = rui.requestHelper.getList("detail.bookCode");
                List<string> priceList = rui.requestHelper.getList("detail.price");
                //将获取数据传给业务类
                string msg = db.bll.bks_book.batchSave(bookCodeList, priceList, dc);
                result.Data = rui.jsonResult.getAJAXResult(msg, true);
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                result.Data = rui.jsonResult.getAJAXResult(rui.excptHelper.getExMsg(ex), false);
            }
            return result;
        }
        //批量上架
        [HttpPost]
        public JsonResult batchSell(string keyFieldValues)
        {
            rui.jsonResult result = new rui.jsonResult();
            try
            {
                string msg = db.bll.bks_book.batchSell(keyFieldValues, dc);
                result.data = rui.jsonResult.getAJAXResult(msg, true);
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                result.data = rui.jsonResult.getAJAXResult(ex.Message, false);
            }
            return Json(result.data);
        }


        //批量下架
        [HttpPost]
        public JsonResult batchNoSell(string keyFieldValues)
        {
            rui.jsonResult result = new rui.jsonResult();
            try
            {
                string msg = db.bll.bks_book.batchNoSell(keyFieldValues, dc);
                result.data = rui.jsonResult.getAJAXResult(msg, true);
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                result.data = rui.jsonResult.getAJAXResult(ex.Message, false);
            }
            return Json(result.data);
        }
        //批量变更图书类别
        [HttpPost]
        public JsonResult batchChangeBookType(string keyFieldValues, string bookTypeCode)
        {
            rui.jsonResult result = new rui.jsonResult();
            try
            {
                string msg = db.bll.bks_book.batchChangeBookType(keyFieldValues, bookTypeCode, dc);
                result.data = rui.jsonResult.getAJAXResult(msg, true);
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                result.data = rui.jsonResult.getAJAXResult(ex.Message, false);
            }
            return Json(result.data);
        }
    }
}