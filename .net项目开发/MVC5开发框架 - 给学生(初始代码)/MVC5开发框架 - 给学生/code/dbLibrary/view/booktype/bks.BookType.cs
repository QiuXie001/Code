using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db.view
{
    public class bks_BookType : rui.pagerBase
    {
        //定义需要的搜索条件
        public long rowNum { get; set; }
        public string rowID { get; set; }
        public string bookTypeCode { get; set; }
        public string bookTypeName { get; set; }
        public int showOrder { get; set; }
        public string remark { get; set; }


        public override void Search()
        {
            this.keyField = "bookTypeCode";
            this.ResourceCode = "bks_BookType";

            //拼接搜索语句
            string querySql = " select * from bks_BookType where 1=1 ";
            querySql += rui.dbTools.searchDdl("bookTypeCode", this.bookTypeCode, this.cmdPara);
            querySql += rui.dbTools.searchTbx("bookTypeName", this.bookTypeName, this.cmdPara);
            querySql += rui.dbTools.searchDdl("remark", this.remark, this.cmdPara);

            //利用搜索语句获取数据
            this.getPageConfig();
            rui.pagerHelper ph = new rui.pagerHelper(querySql, this.getOrderSql("rowNum", "asc"), this);
            ph.Execute(this.PageSize, this.PageIndex, this);
            this.dataTable = ph.Result;
            //获取要展示的列配置
            this.showColumn = this.getShowColumn();

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
