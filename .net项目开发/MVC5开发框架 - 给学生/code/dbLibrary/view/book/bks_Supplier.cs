using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.view
{
    public class bks_Supplier:rui.pagerBase
    {
        //定义需要的搜索条件
        public string supplierName { get; set; }
        public string contactUser { get; set; }
        public string contactPhone { get; set; }
        public override void Search()
        {
            this.keyField = "supplierCode";
            this.ResourceCode = "bks_Supplier";

            //拼接搜索语句
            string querySql = " select * from bks_Supplier where 1=1 ";
            querySql += rui.dbTools.searchDdl("supplierName", this.supplierName, this.cmdPara);
            querySql += rui.dbTools.searchDdl("contactUser", this.contactUser, this.cmdPara);
            querySql += rui.dbTools.searchTbx("contactPhone", this.contactPhone, this.cmdPara);

            //利用搜索语句获取数据
            this.getPageConfig();
            rui.pagerHelper ph = new rui.pagerHelper(querySql, this.getOrderSql("rowNum", "asc"), this);
            ph.Execute(this.PageSize, this.PageIndex, this);
            this.dataTable = ph.Result;
            //获取要展示的列配置
            this.showColumn = this.getShowColumn();
        }
    }
}
