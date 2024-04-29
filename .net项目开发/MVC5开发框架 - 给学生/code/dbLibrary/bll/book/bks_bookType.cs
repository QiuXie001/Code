using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace db.bll
{
    public class bks_BookType
    {
        private static string YesOrNot = "是,否";

        /// <summary>
        /// 利用代码生成图书编号
        /// 编码规则：B201205020001,B201205020002
        /// </summary>
        /// <param name="dc"></param>
        /// <returns></returns>
        private static string _createCode(db.dbEntities dc)
        {
            //string Code = "B" + DateTime.Now.ToString("yyyyMMdd");
            //string result = (from a in dc.bks_BookType
            //                 where a.bookTypeCode.StartsWith(Code)
            //                 select a.bookTypeCode).Max();
            //if (result != null)
            //{
            //    Code = rui.stringHelper.codeNext(result, 4);
            //}
            //else
            //{
            //    Code = Code + "0001";
            //}
            //return Code;

            //雪花编码
            return idHelper.nextId().ToString();
        }

        //并发性比较高，编号没规律要求用(雪花编码)方案
        private static rui.idWorker idHelper = new rui.idWorker();

        //对字段的相关合法性进行检查
        private static void _checkInput(db.bks_BookType entry)
        {
            efHelper.checkNotNull(entry.bookTypeCode, "图书编号");
            efHelper.checkNotNull(entry.bookTypeName, "图书名称");
            efHelper.checkNotNull(entry.bookTypeCode, "图书类型");
        }

        public static string batchSave(List<string> showOrderList, List<string> bookTypeCodeList, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);
            Dictionary<string, string> errorDic = new Dictionary<string, string>();
            for (int i = 0; i < bookTypeCodeList.Count; i++)
            {
                try
                {
                    //采用Dapper的方式写代码,变量都定义为参数
                    string sql = " UPDATE dbo.bks_BookType SET showOrder=@showOrder WHERE bookTypeCode=@bookTypeCode ";
                    if (ef.Execute(sql, new { showOrder = showOrderList[i], bookTypeCode = bookTypeCodeList[i] }) == 0)
                        rui.excptHelper.throwEx("数据未变更");
                }
                catch (Exception ex)
                {
                    errorDic.Add(showOrderList[i], rui.excptHelper.getExMsg(ex));
                    rui.logHelper.log(ex);
                }
            }
            return rui.dbTools.getBatchMsg("批量保存", bookTypeCodeList.Count, errorDic);

        }
        /// <summary>
        /// 绑定图书类别
        /// </summary>
        /// <param name="has请选择"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        

        /// <summary>
        /// 绑定是否
        /// </summary>
        /// <param name="has请选择"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        /// 
        public static List<SelectListItem> bindYesOrNot(bool has请选择 = false, string selectedValue = "")
        {
            return rui.listHelper.bindValues(YesOrNot, has请选择, selectedValue);
        }


        public static string getNameByCode(string keyCode, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            string sql = "select bookTypeName from dbo.bks_BookType where bookTypeCode=@bookTypeCode ";
            object value = ef.ExecuteScalar(sql, new { bookTypeCode = keyCode });
            return rui.typeHelper.toString(value);
        }
        //新增
        public static string insert(db.bks_BookType entry, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            if (rui.typeHelper.isNullOrEmpty(entry.bookTypeCode))
                entry.bookTypeCode = _createCode(dc);
            else if (dc.bks_BookType.Count(a => a.bookTypeCode == entry.bookTypeCode) > 0)
            {
                rui.excptHelper.throwEx("编号已存在");
            }

            //检查数据合法性
            _checkInput(entry);

            //设置字段默认值
            entry.rowID = ef.newGuid();
            dc.bks_BookType.Add(entry);
            dc.SaveChanges();
            return entry.rowID;
        }

        //修改
        public static void update(db.bks_BookType entry, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            //检查数据合法性
            _checkInput(entry);

            efHelper.entryUpdate(entry, dc);
            dc.SaveChanges();
        }

        //删除
        public static void delete(string rowID, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);
            try
            {
                string keyCode = getCodeByRowID(rowID, dc);
                //删除前检查
                ef.checkCanDelete("bks_BookTypeStockDetail", "bookTypeCode", keyCode, "已进货，不允许删除");
                ef.checkCanDelete("bks_ShoppingTrolley", "bookTypeCode", keyCode, "已被用户加入购物车，不允许删除");
                ef.checkCanDelete("bks_OrderDetail", "bookTypeCode", keyCode, "已被客户采购，不允许删除");

                //删除
                ef.Execute("DELETE from dbo.bks_BookType where rowID=@rowID ", new { rowID });
            }
            catch (Exception ex)
            {
                rui.logHelper.log(ex);
                throw ex;
            }
        }

        //通过rowID获取主键
        public static string getCodeByRowID(string rowID, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            string sql = "select bookTypeCode from dbo.bks_BookType where rowID=@rowID ";
            object value = ef.ExecuteScalar(sql, new { rowID });
            return rui.typeHelper.toString(value);
        }

        //通过rowID获取名称
        public static string getNameByRowID(string rowID, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            string sql = "select bookTypeName from dbo.bks_BookType where rowID=@rowID ";
            object value = ef.ExecuteScalar(sql, new { rowID });
            return rui.typeHelper.toString(value);
        }


        //获取实体
        public static db.bks_BookType getEntryByRowID(string rowID, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc); dc = ef.dc;

            db.bks_BookType entry = dc.bks_BookType.Single(a => a.rowID == rowID);
            return entry;
        }

        //获取实体
        public static db.bks_BookType getEntryByCode(string keyCode, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            db.bks_BookType entry = dc.bks_BookType.SingleOrDefault(a => a.bookTypeCode == keyCode);
            return entry;
        }

        public static string Sell(string bookTypeCode, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            List<string> KeyFieldList = rui.dbTools.getList(bookTypeCode);
            Dictionary<string, string> errorDic = new Dictionary<string, string>();

            //查询批量操作中已显示的记录，用于提示
            string sqlCheck = " SELECT bookTypeCode,isSell FROM dbo.bks_BookType WHERE bookTypeCode = @bookTypeCode AND isSell='是' ";
            DataTable table = ef.ExecuteDataTable(sqlCheck, new { bookTypeCode = bookTypeCode });

            try
            {
                DataRow[] rows = table.Select("bookTypeCode='" + bookTypeCode + "'");
                rui.dbTools.checkRowFieldValue(rows, "isSell", "是", "已上架");

                string sql = " UPDATE bks_BookType SET isSell='是' WHERE bookTypeCode=@bookTypeCode ";
                if (ef.Execute(sql, new { bookTypeCode }) == 0)
                    rui.excptHelper.throwEx("数据未变更");
            }
            catch (Exception ex)
            {
                errorDic.Add(bookTypeCode, rui.excptHelper.getExMsg(ex));
                rui.logHelper.log(ex);
            }

            return rui.dbTools.getBatchMsg("上架", 1, errorDic);
        }
        /// <summary>
        /// 批量下架
        /// </summary>
        /// <param name="keyFieldValues"></param>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static string NoSell(string bookTypeCode, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            Dictionary<string, string> errorDic = new Dictionary<string, string>();

            //查询批量操作中已显示的记录，用于提示
            string sqlCheck = " SELECT bookTypeCode,isSell FROM dbo.bks_BookType WHERE bookTypeCode = @bookTypeCode AND isSell='否' ";
            DataTable table = ef.ExecuteDataTable(sqlCheck, new { bookTypeCode = bookTypeCode });

            try
            {
                //检查遍历的数据是否已下架
                DataRow[] rows = table.Select("bookTypeCode='" + bookTypeCode + "'");
                rui.dbTools.checkRowFieldValue(rows, "isSell", "否", "已下架");

                string sql = " UPDATE bks_BookType SET isSell='否' WHERE bookTypeCode=@bookTypeCode ";
                if (ef.Execute(sql, new { bookTypeCode }) == 0)
                    rui.excptHelper.throwEx("数据未变更");
            }
            catch (Exception ex)
            {
                errorDic.Add(bookTypeCode, rui.excptHelper.getExMsg(ex));
                rui.logHelper.log(ex);
            }
            return rui.dbTools.getBatchMsg("下架", 1, errorDic);
        }
        /// <summary>
        /// 批量上架
        /// </summary>
        /// <param name="keyFieldValues"></param>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static string batchSell(string keyFieldValues, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            List<string> KeyFieldList = rui.dbTools.getList(keyFieldValues);
            Dictionary<string, string> errorDic = new Dictionary<string, string>();

            //查询批量操作中已显示的记录，用于提示
            string sqlCheck = " SELECT bookTypeCode,isSell FROM dbo.bks_BookType WHERE bookTypeCode IN @bookTypeCode AND isSell='是' ";
            DataTable table = ef.ExecuteDataTable(sqlCheck, new { bookTypeCode = KeyFieldList });

            foreach (string bookTypeCode in KeyFieldList)
            {
                try
                {
                    DataRow[] rows = table.Select("bookTypeCode='" + bookTypeCode + "'");
                    rui.dbTools.checkRowFieldValue(rows, "isSell", "是", "已上架");

                    string sql = " UPDATE bks_BookType SET isSell='是' WHERE bookTypeCode=@bookTypeCode ";
                    if (ef.Execute(sql, new { bookTypeCode }) == 0)
                        rui.excptHelper.throwEx("数据未变更");
                }
                catch (Exception ex)
                {
                    errorDic.Add(bookTypeCode, rui.excptHelper.getExMsg(ex));
                    rui.logHelper.log(ex);
                }
            }
            return rui.dbTools.getBatchMsg("批量上架", KeyFieldList.Count, errorDic);
        }
        /// <summary>
        /// 批量下架
        /// </summary>
        /// <param name="keyFieldValues"></param>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static string batchNoSell(string keyFieldValues, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            List<string> KeyFieldList = rui.dbTools.getList(keyFieldValues);
            Dictionary<string, string> errorDic = new Dictionary<string, string>();

            //查询批量操作中已显示的记录，用于提示
            string sqlCheck = " SELECT bookTypeCode,isSell FROM dbo.bks_BookType WHERE bookTypeCode IN @bookTypeCode AND isSell='否' ";
            DataTable table = ef.ExecuteDataTable(sqlCheck, new { bookTypeCode = KeyFieldList });

            foreach (string bookTypeCode in KeyFieldList)
            {
                try
                {
                    //检查遍历的数据是否已下架
                    DataRow[] rows = table.Select("bookTypeCode='" + bookTypeCode + "'");
                    rui.dbTools.checkRowFieldValue(rows, "isSell", "否", "已下架");

                    string sql = " UPDATE bks_BookType SET isSell='否' WHERE bookTypeCode=@bookTypeCode ";
                    if (ef.Execute(sql, new { bookTypeCode }) == 0)
                        rui.excptHelper.throwEx("数据未变更");
                }
                catch (Exception ex)
                {
                    errorDic.Add(bookTypeCode, rui.excptHelper.getExMsg(ex));
                    rui.logHelper.log(ex);
                }
            }
            return rui.dbTools.getBatchMsg("批量下架", KeyFieldList.Count, errorDic);
        }
        /// <summary>
        /// 批量变更图书类别
        /// </summary>
        /// <param name="keyFieldValues"></param>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static string batchChangeBookType(string keyFieldValues, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            List<string> KeyFieldList = rui.dbTools.getList(keyFieldValues);
            Dictionary<string, string> errorDic = new Dictionary<string, string>();

            foreach (string bookTypeCode in KeyFieldList)
            {
                try
                {
                    string sql = " UPDATE bks_BookType SET bookTypeCode=@bookTypeCode WHERE bookTypeCode=@bookTypeCode ";
                    if (ef.Execute(sql, new { bookTypeCode }) == 0)
                        rui.excptHelper.throwEx("数据未变更");
                }
                catch (Exception ex)
                {
                    errorDic.Add(bookTypeCode, rui.excptHelper.getExMsg(ex));
                    rui.logHelper.log(ex);
                }
            }
            return rui.dbTools.getBatchMsg("批量变更图书类型", KeyFieldList.Count, errorDic);
        }
        //返回出版社下拉框绑定项目
        public static List<SelectListItem> bindDdl(bool has请选择 = false, string selectedValue = "", string bookTypeCode = "", string PressCode = "")
        {
            efHelper ef = new efHelper();
            string sql = " SELECT bookTypeCode AS code,bookTypeName AS name FROM dbo.bks_BookType where 1=1 ";
            if (rui.typeHelper.isNotNullOrEmpty(bookTypeCode))
                sql += " and bookTypeCode='" + bookTypeCode + "' ";
            if (rui.typeHelper.isNotNullOrEmpty(PressCode))
                sql += " and PressCode='" + PressCode + "' ";
            sql += " ORDER BY bookTypeCode ASC ";
            DataTable table = ef.ExecuteDataTable(sql);
            List<SelectListItem> list = rui.listHelper.dataTableToDdlList(table, has请选择, selectedValue);
            return list;
        }
        //获取联动的图书列表Json数据
        public static string getJsonBookDdl(string bookTypeCode = "", string PressCode = "")
        {
            return rui.jsonResult.SelectListToJsonStr(bindDdl(false, "", bookTypeCode, PressCode));
        }
    }
}
