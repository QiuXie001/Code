using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.view
{
    public class bks_BookType:rui.pagerBase
    {
        //定义需要的搜索条件
        public string bookTypeCode { get; set; }
        public string bookTypeName { get; set; }
        public string showOrder { get; set; }
        public string remark { get; set; }
        public override void Search()
        {
            this.keyField = "bookTypeCode";
            this.ResourceCode = "bks_BookType";

            //拼接搜索语句,改这边，下面不需要修改
            string querySql = " select * from bks_BookType where 1=1 ";
            querySql += rui.dbTools.searchDdl("bookTypeCode", this.bookTypeCode, this.cmdPara);
            querySql += rui.dbTools.searchDdl("bookTypeName", this.bookTypeName, this.cmdPara);
            querySql += rui.dbTools.searchTbx("showOrder", this.showOrder, this.cmdPara);
            querySql += rui.dbTools.searchDate("remark", this.remark, this.remark, this.cmdPara);

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
