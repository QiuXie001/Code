using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.bll
{
    public class bks_book
    {
        public static string batchSave(List<string> bookCodeList, List<string> priceList, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);
            Dictionary<string, string> errorDic = new Dictionary<string, string>();
            for (int i = 0; i < bookCodeList.Count; i++)
            {
                try
                {
                    //采用Dapper的方式写代码,变量都定义为参数
                    string sql = " UPDATE dbo.bks_Book SET price=@price WHERE bookCode=@bookCode ";
                    if (ef.Execute(sql, new { price = priceList[i], bookCode = bookCodeList[i] }) == 0)
                        rui.excptHelper.throwEx("数据未变更");
                }
                catch (Exception ex)
                {
                    errorDic.Add(bookCodeList[i], rui.excptHelper.getExMsg(ex));
                    rui.logHelper.log(ex);
                }
            }
            return rui.dbTools.getBatchMsg("批量保存", bookCodeList.Count, errorDic);

        }

        public static string Sell(string bookCode, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            List<string> KeyFieldList = rui.dbTools.getList(bookCode);
            Dictionary<string, string> errorDic = new Dictionary<string, string>();

            //查询批量操作中已显示的记录，用于提示
            string sqlCheck = " SELECT bookCode,isSell FROM dbo.bks_Book WHERE bookCode = @bookCode AND isSell='是' ";
            DataTable table = ef.ExecuteDataTable(sqlCheck, new { bookCode = bookCode });

            try
            {
                DataRow[] rows = table.Select("bookCode='" + bookCode + "'");
                rui.dbTools.checkRowFieldValue(rows, "isSell", "是", "已上架");

                string sql = " UPDATE bks_Book SET isSell='是' WHERE bookCode=@bookCode ";
                if (ef.Execute(sql, new { bookCode }) == 0)
                    rui.excptHelper.throwEx("数据未变更");
            }
            catch (Exception ex)
            {
                errorDic.Add(bookCode, rui.excptHelper.getExMsg(ex));
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
        public static string NoSell(string bookCode, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            Dictionary<string, string> errorDic = new Dictionary<string, string>();

            //查询批量操作中已显示的记录，用于提示
            string sqlCheck = " SELECT bookCode,isSell FROM dbo.bks_Book WHERE bookCode = @bookCode AND isSell='否' ";
            DataTable table = ef.ExecuteDataTable(sqlCheck, new { bookCode = bookCode });

            try
            {
                //检查遍历的数据是否已下架
                DataRow[] rows = table.Select("bookCode='" + bookCode + "'");
                rui.dbTools.checkRowFieldValue(rows, "isSell", "否", "已下架");

                string sql = " UPDATE bks_Book SET isSell='否' WHERE bookCode=@bookCode ";
                if (ef.Execute(sql, new { bookCode }) == 0)
                    rui.excptHelper.throwEx("数据未变更");
            }
            catch (Exception ex)
            {
                errorDic.Add(bookCode, rui.excptHelper.getExMsg(ex));
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
            string sqlCheck = " SELECT bookCode,isSell FROM dbo.bks_Book WHERE bookCode IN @bookCode AND isSell='是' ";
            DataTable table = ef.ExecuteDataTable(sqlCheck, new { bookCode = KeyFieldList });

            foreach (string bookCode in KeyFieldList)
            {
                try
                {
                    DataRow[] rows = table.Select("bookCode='" + bookCode + "'");
                    rui.dbTools.checkRowFieldValue(rows, "isSell", "是", "已上架");

                    string sql = " UPDATE bks_Book SET isSell='是' WHERE bookCode=@bookCode ";
                    if (ef.Execute(sql, new { bookCode }) == 0)
                        rui.excptHelper.throwEx("数据未变更");
                }
                catch (Exception ex)
                {
                    errorDic.Add(bookCode, rui.excptHelper.getExMsg(ex));
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
            string sqlCheck = " SELECT bookCode,isSell FROM dbo.bks_Book WHERE bookCode IN @bookCode AND isSell='否' ";
            DataTable table = ef.ExecuteDataTable(sqlCheck, new { bookCode = KeyFieldList });

            foreach (string bookCode in KeyFieldList)
            {
                try
                {
                    //检查遍历的数据是否已下架
                    DataRow[] rows = table.Select("bookCode='" + bookCode + "'");
                    rui.dbTools.checkRowFieldValue(rows, "isSell", "否", "已下架");

                    string sql = " UPDATE bks_Book SET isSell='否' WHERE bookCode=@bookCode ";
                    if (ef.Execute(sql, new { bookCode }) == 0)
                        rui.excptHelper.throwEx("数据未变更");
                }
                catch (Exception ex)
                {
                    errorDic.Add(bookCode, rui.excptHelper.getExMsg(ex));
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
        public static string batchChangeBookType(string keyFieldValues, string bookTypeCode, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            List<string> KeyFieldList = rui.dbTools.getList(keyFieldValues);
            Dictionary<string, string> errorDic = new Dictionary<string, string>();

            foreach (string bookCode in KeyFieldList)
            {
                try
                {
                    string sql = " UPDATE bks_Book SET bookTypeCode=@bookTypeCode WHERE bookCode=@bookCode ";
                    if (ef.Execute(sql, new { bookCode, bookTypeCode }) == 0)
                        rui.excptHelper.throwEx("数据未变更");
                }
                catch (Exception ex)
                {
                    errorDic.Add(bookCode, rui.excptHelper.getExMsg(ex));
                    rui.logHelper.log(ex);
                }
            }
            return rui.dbTools.getBatchMsg("批量变更图书类型", KeyFieldList.Count, errorDic);
        }
    }
}
