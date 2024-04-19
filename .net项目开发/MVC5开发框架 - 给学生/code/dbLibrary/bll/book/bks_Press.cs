using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace db.bll
{
    public class bks_Press
    {
        public static List<SelectListItem> bindDdl(bool has请选择 = false, string selectedValue = "")
        {
            efHelper ef = new efHelper();
            string sql = " SELECT pressCode as code,pressName as name FROM dbo.bks_Press order by pressCode desc ";
            DataTable table = ef.ExecuteDataTable(sql);
            return rui.listHelper.dataTableToDdlList(table, has请选择, selectedValue);
        }

    }
}
