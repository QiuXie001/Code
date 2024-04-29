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
        /// <summary>
        /// 利用代码生成出版社编号
        /// 编码规则：B201205020001,B201205020002
        /// </summary>
        /// <param name="dc"></param>
        /// <returns></returns>
        private static string _createCode(db.dbEntities dc)
        {
            //string Code = "B" + DateTime.Now.ToString("yyyyMMdd");
            //string result = (from a in dc.bks_Press
            //                 where a.pressCode.StartsWith(Code)
            //                 select a.pressCode).Max();
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
        private static void _checkInput(db.bks_Press entry)
        {
            efHelper.checkNotNull(entry.pressCode, "出版社编号");
            efHelper.checkNotNull(entry.pressName, "出版社名称");
        }
        public static string getNameByCode(string keyCode, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            string sql = "select pressName from dbo.bks_Press where pressCode=@pressCode ";
            object value = ef.ExecuteScalar(sql, new { pressCode = keyCode });
            return rui.typeHelper.toString(value);
        }//新增
        public static string insert(db.bks_Press entry, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            if (rui.typeHelper.isNullOrEmpty(entry.pressCode))
                entry.pressCode = _createCode(dc);
            else if (dc.bks_Press.Count(a => a.pressCode == entry.pressCode) > 0)
            {
                rui.excptHelper.throwEx("编号已存在");
            }

            //检查数据合法性
            _checkInput(entry);

            //设置字段默认值
            entry.rowID = ef.newGuid();
            dc.bks_Press.Add(entry);
            dc.SaveChanges();
            return entry.rowID;
        }

        //修改
        public static void update(db.bks_Press entry, db.dbEntities dc)
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
                ef.checkCanDelete("bks_PressStockDetail", "pressCode", keyCode, "已进货，不允许删除");
                ef.checkCanDelete("bks_ShoppingTrolley", "pressCode", keyCode, "已被用户加入购物车，不允许删除");
                ef.checkCanDelete("bks_OrderDetail", "pressCode", keyCode, "已被客户采购，不允许删除");

                //删除
                ef.Execute("DELETE from dbo.bks_Press where rowID=@rowID ", new { rowID });
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

            string sql = "select pressCode from dbo.bks_Press where rowID=@rowID ";
            object value = ef.ExecuteScalar(sql, new { rowID });
            return rui.typeHelper.toString(value);
        }

        //通过rowID获取名称
        public static string getNameByRowID(string rowID, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            string sql = "select pressName from dbo.bks_Press where rowID=@rowID ";
            object value = ef.ExecuteScalar(sql, new { rowID });
            return rui.typeHelper.toString(value);
        }


        //获取实体
        public static db.bks_Press getEntryByRowID(string rowID, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc); dc = ef.dc;

            db.bks_Press entry = dc.bks_Press.Single(a => a.rowID == rowID);
            return entry;
        }

        //获取实体
        public static db.bks_Press getEntryByCode(string keyCode, db.dbEntities dc)
        {
            efHelper ef = new efHelper(ref dc);

            db.bks_Press entry = dc.bks_Press.SingleOrDefault(a => a.pressCode == keyCode);
            return entry;
        }
    }
}
