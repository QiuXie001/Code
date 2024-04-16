using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.bll
{
    public class bks_bookType
    {
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
    }
}
