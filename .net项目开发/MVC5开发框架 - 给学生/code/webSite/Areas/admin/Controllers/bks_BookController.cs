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
                string msg = db.bll.bks_Book.Sell(bookCode, dc);
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
                string msg = db.bll.bks_Book.NoSell(bookCode, dc);
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
                string msg = db.bll.bks_Book.batchSave(bookCodeList, priceList, dc);
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
                string msg = db.bll.bks_Book.batchSell(keyFieldValues, dc);
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
                string msg = db.bll.bks_Book.batchNoSell(keyFieldValues, dc);
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
                string msg = db.bll.bks_Book.batchChangeBookType(keyFieldValues, bookTypeCode, dc);
                result.data = rui.jsonResult.getAJAXResult(msg, true);
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                result.data = rui.jsonResult.getAJAXResult(ex.Message, false);
            }
            return Json(result.data);
        }
        //获取联动的图书列表
        public JsonResult getBookCodeDdl(string bookTypeCode, string PressCode = "")
        {
            rui.jsonResult result = new rui.jsonResult();
            try
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("bookList", db.bll.bks_Book.getJsonBookDdl(bookTypeCode, PressCode));
                result.data = rui.jsonResult.getAJAXResult("获取成功", true, dic);
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                result.data = rui.jsonResult.getAJAXResult(ex.Message, false);
            }
            return Json(result.data);
        }

        //详情
        public ActionResult Detail(string rowID)
        {
            db.bks_Book model = db.bll.bks_Book.getEntryByRowID(rowID, dc);
            model.bookTypeCode = bks_BookType.getNameByCode(model.bookTypeCode, dc);
            model.pressCode = bks_Press.getNameByCode(model.pressCode, dc);
            return View(model);
        }

        //展示新增
        [HttpGet]
        public ActionResult Insert()
        {
            db.bks_Book model = new db.bks_Book();
            return View(model);
        }

        //保存新增
        [HttpPost]
        public JsonResult Insert(db.bks_Book model)
        {
            JsonResult result = new JsonResult();
            try
            {
                if (ModelState.IsValid)
                {
                    string rowID = db.bll.bks_Book.insert(model, dc);
                    result.Data = rui.jsonResult.getAJAXResult("新增成功", true,
                        rui.jsonResult.getDicByRowID(rowID));
                }
                else
                {
                    result.Data = rui.jsonResult.getAJAXResult("输入不合法", false);
                }
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                result.Data = rui.jsonResult.getAJAXResult(ex.Message, false);
            }
            return result;
        }

        //展示更新
        [HttpGet]
        public ActionResult Update(string rowID)
        {
            db.bks_Book model = db.bll.bks_Book.getEntryByRowID(rowID, dc);
            model.bookTypeCode = bks_BookType.getNameByCode(model.bookTypeCode, dc);
            model.pressCode = bks_Press.getNameByCode(model.pressCode, dc);
            return View(model);
        }

        //保存更新
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(db.bks_Book model)
        {
            JsonResult result = new JsonResult();
            try
            {
                if (ModelState.IsValid)
                {
                    db.bll.bks_Book.update(model, dc);
                    result.Data = rui.jsonResult.getAJAXResult("更新成功", true);
                }
                else
                {
                    result.Data = rui.jsonResult.getAJAXResult("输入不合法", false);
                }
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                result.Data = rui.jsonResult.getAJAXResult(ex.Message, false);
            }
            return result;
        }

        //删除
        [HttpPost]
        public JsonResult Delete(string rowID)
        {
            JsonResult result = new JsonResult();
            try
            {
                db.bll.bks_Book.delete(rowID, dc);
                result.Data = rui.jsonResult.getAJAXResult("删除成功", true);
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                result.Data = rui.jsonResult.getAJAXResult(ex.Message, false);
            }
            return result;
        }
    }
}