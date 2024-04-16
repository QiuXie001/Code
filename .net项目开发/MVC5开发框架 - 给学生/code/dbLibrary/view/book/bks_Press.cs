using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.view
{
    public class bks_Press:rui.pagerBase
    {
        //定义需要的搜索条件
        public string pressName { get; set; }
        public string pressCode { get; set; }
        public string showOrder { get; set; }
        public override void Search()
        {
            this.keyField = "pressCode";
            this.ResourceCode = "bks_Press";

            //拼接搜索语句
            string querySql = " select * from bks_Press where 1=1 ";
            querySql += rui.dbTools.searchDdl("pressName", this.pressName, this.cmdPara);
            querySql += rui.dbTools.searchDdl("pressCode", this.pressCode, this.cmdPara);

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
