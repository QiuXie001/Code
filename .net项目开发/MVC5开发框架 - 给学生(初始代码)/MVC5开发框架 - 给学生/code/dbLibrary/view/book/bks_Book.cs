using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.view
{
    public class bks_Book : rui.pagerBase
    {
        //定义需要的搜索条件
        public string bookTypeCode { get; set; }
        public string pressCode { get; set; }
        public string bookName { get; set; }
        public string pressDateStart { get; set; }
        public string pressDateEnd { get; set; }
        public string isSell { get; set; }


        public override void Search()
        {
            this.keyField = "bookCode";
            this.ResourceCode = "bks_Book";

            //拼接搜索语句
            string querySql = " select * from sv_bks_Book where 1=1 ";
            querySql += rui.dbTools.searchDdl("bookTypeCode", this.bookTypeCode, this.cmdPara);
            querySql += rui.dbTools.searchDdl("pressCode", this.pressCode, this.cmdPara);
            querySql += rui.dbTools.searchTbx("bookName", this.bookName, this.cmdPara);
            querySql += rui.dbTools.searchDate("pressDate", this.pressDateStart, this.pressDateEnd, this.cmdPara);
            querySql += rui.dbTools.searchDdl("isSell", this.isSell, this.cmdPara);

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
