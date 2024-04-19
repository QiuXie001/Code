using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace db.bll
{
    public class bks_bookType
    {
        private static string YesOrNot = "是,否";
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
        public static List<SelectListItem> bindDdl(bool has请选择 = false, string selectedValue = "")
        {
            efHelper ef = new efHelper();
            string sql = " SELECT bookTypeCode as code,bookTypeName as name FROM dbo.bks_BookType order by bookTypeCode desc ";
            DataTable table = ef.ExecuteDataTable(sql);
            return rui.listHelper.dataTableToDdlList(table, has请选择, selectedValue);
        }
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
    }
}
