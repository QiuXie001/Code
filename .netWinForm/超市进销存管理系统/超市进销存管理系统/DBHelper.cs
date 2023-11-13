using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市进销存管理系统
{
    public class DBHelper
    {
        //返回连接字符串
        public static string getConnstr()
        {
            return
            @"Data Source=DESKTOP-RNM42BF;Initial Catalog=Supermakat;User ID=sa;Password=123456";
        }
        //执行Sql操作（增、删、改或 不含查询表格的存储过程）
        public static int ExecuteNonQuery(string sql, List<SqlParameter> paraList = null,
            CommandType commType = CommandType.Text)
        {
            int result = 0;
            SqlConnection conn = new SqlConnection();  //创建连接对象
            try
            {
                conn.ConnectionString = DBHelper.getConnstr();    //设置连接串
                conn.Open();  //打开连接
                SqlCommand comm = new SqlCommand(); //创建命令对象
                comm.Connection = conn;     //设置命令对象的所用连接
                comm.CommandText = sql;  //设置命令文本
                comm.CommandType = commType;     //设置命令类型
                comm.CommandTimeout = 600;  //超时时间
                if (paraList != null)
                {  //给命令添加参数----------
                    foreach (SqlParameter para in paraList)
                        comm.Parameters.Add(para);
                }
                result = comm.ExecuteNonQuery();  //执行命令，得到受影响的行数
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();   //关闭连接
            }

        }


        //汇总查询
        public static object ExecuteScale(string sql, List<SqlParameter> paraList = null,
            CommandType commType = CommandType.Text)
        {
            object value;
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = DBHelper.getConnstr();
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = sql;
                comm.CommandType = commType;
                comm.CommandTimeout = 600;
                if (paraList != null)
                {  //给命令添加参数----------
                    foreach (SqlParameter para in paraList)
                        comm.Parameters.Add(para);
                }
                value = comm.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return value;
        }


        //连线查询 -拉水管（查询，返回一个表格）  一定要通过dr.close()关闭连接对象
        public static SqlDataReader ExecuteReader(string sql, List<SqlParameter> paraList = null,
            CommandType commType = CommandType.Text)
        {
            SqlDataReader dr; //
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = DBHelper.getConnstr();
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = sql;
                comm.CommandType = commType;
                comm.CommandTimeout = 600;
                if (paraList != null)
                {  //给命令添加参数----------
                    foreach (SqlParameter para in paraList)
                        comm.Parameters.Add(para);
                }
                dr = comm.ExecuteReader(CommandBehavior.CloseConnection); //             
                return dr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //汇总查询
        public static object ExecuteScalar(string sql)
        {
            object value;
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = DBHelper.getConnstr();
                conn.Open();
                SqlCommand comm = new SqlCommand();
                comm.Connection = conn;
                comm.CommandText = sql;
                comm.CommandTimeout = 600;

                value = comm.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return value;
        }
        //事务封装，多个Sql一起执行
        public static void ExecuteNonQueryTransaction(List<string> sqlList)
        {
            SqlConnection conn = new SqlConnection();
            SqlTransaction trans = null; // 定义事务
            try
            {
                conn.ConnectionString = DBHelper.getConnstr();
                conn.Open();
                trans = conn.BeginTransaction(); // 创建事务
                foreach (string sql in sqlList)
                {
                    SqlCommand comm = conn.CreateCommand();
                    comm.CommandText = sql;
                    comm.Transaction = trans; //命令事务对象
                    comm.ExecuteNonQuery();
                }
                trans.Commit(); //  提交事务
            }
            catch (Exception ex)
            {
                trans.Rollback();  //  回滚事务
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }
        //创建一个参数
        public static SqlParameter createPara(string paraName, SqlDbType paraType,
            ParameterDirection paraDire = ParameterDirection.Input, object paraValue = null,
             int paraSize = 0)
        {
            SqlParameter para = new SqlParameter();
            para.ParameterName = paraName; //参数名
            para.SqlDbType = paraType; //参数类型
            para.Direction = paraDire; //参数方向
            if (paraValue != null)
                para.Value = paraValue;  //参数值
            if (paraSize != 0)
                para.Size = paraSize;   //参数大小
            return para;
        }
        //离线查询 ，返回DataTable
        public static DataTable ExecuteAdapter(string sql, List<SqlParameter> paraList = null,
            CommandType commType = CommandType.Text)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = DBHelper.getConnstr();
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                comm.CommandType = commType;
                if (paraList != null)
                {  //给命令添加参数----------
                    foreach (SqlParameter para in paraList)
                        comm.Parameters.Add(para);
                }
                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable tb = new DataTable();
                da.Fill(tb);
                return tb;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();   //不能关闭连接，水管断开
            }
        }
        public static int Emp_Exist(string uid, string pwd)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection(getConnstr());
            con.Open();
            string sql="select count(*) from s_user where UserID='"+uid+"'and UserPWD='"+pwd+"'";
            cmd = new SqlCommand(sql, con);
            object b = cmd.ExecuteScalar();
            if (b.Equals(0))
                return 0;
            else
                return 1;
        }
        public static int User_ID_Exist(string uid)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection(getConnstr());
            con.Open();
            string sql = "select count(*) from s_user where UserID='" + uid + "'";
            cmd = new SqlCommand(sql, con);
            object b = cmd.ExecuteScalar();
            if (b.Equals(0))
                return 0;
            else
                return 1;
        }
        public static int Com_ID_Exist(string id)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection(getConnstr());
            con.Open();
            string sql = "select count(*) from s_supplier where SupplierID ='" + id + "'";
            cmd = new SqlCommand(sql, con);
            object b = cmd.ExecuteScalar();
            if (b.Equals(0))
                return 0;
            else
                return 1;
        }
        public static int Vip_Exist(string tel)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection(getConnstr());
            con.Open();
            string sql = "select count(*) from s_custom where CustomPhone = '" + tel + "'"; 
            cmd = new SqlCommand(sql, con);
            object b = cmd.ExecuteScalar();
            if (b.Equals(0))
                return 1;
            else
                return 0;
        }
        public static int Good_Exist(string good)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection(getConnstr());
            con.Open();
            string sql = "select count(*) from receipt where ProductID  = '" + good + "'";
            cmd = new SqlCommand(sql, con);
            object b = cmd.ExecuteScalar();
            if (b.Equals(0))
                return 1;
            else
                return 0;
        }
        public static int Receipt_Exist()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dr;
            con = new SqlConnection(getConnstr());
            con.Open();
            string sql = "select count(*) from receipt ";
            cmd = new SqlCommand(sql, con);
            object b = cmd.ExecuteScalar();
            if (b.Equals(0))
                return 1;
            else
                return 0;
        }
        public static int Product_ID_Exist(string id)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = new SqlConnection(getConnstr());
            con.Open();
            string sql = "select count(*) from s_product where ProductID = '"+ id +"'";
            cmd = new SqlCommand(sql, con);
            object b = cmd.ExecuteScalar();
            if (b.Equals(0))
                return 1;
            else
                return 0;
        }
        public static int Custom_ID_Exist(string id)
        {
            SqlConnection con;
            SqlCommand cmd;
            con = new SqlConnection(getConnstr());
            con.Open();
            string sql = "select count(*) from s_custom where CustomID  = '" + id + "'";
            cmd = new SqlCommand(sql, con);
            object b = cmd.ExecuteScalar();
            if (b.Equals(0))
                return 1;
            else
                return 0;
        }
        public static SqlDataReader Obtain(string sql,out SqlConnection conn)
        {
            SqlConnection con = new SqlConnection(getConnstr());
            con.Open(); //打开数据库
            //以上操作为登录数据库的操作
            SqlCommand com = new SqlCommand(sql, con);
            SqlDataReader read = com.ExecuteReader();  //用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
            conn = con;
            return read;

        }
        public static string[] GetColumnsByDataTable(DataTable dt)
        {
            string[] strColumns = null;


            if (dt.Columns.Count > 0)
            {
                int columnNum = 0;
                columnNum = dt.Columns.Count;
                strColumns = new string[columnNum];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    strColumns[i] = dt.Columns[i].ColumnName;
                }
            }
            return strColumns;
        }
        public static bool IsHandset(string str_handset)
        {
            if (str_handset.Length == 11)
                return System.Text.RegularExpressions.Regex.IsMatch(str_handset, @"^[1]+[3,4,5,7,8,9]+\d{9}");

            return false;
        }
        public static bool CheckIDCard18(string idNumber)

        {

            long n = 0;

            if (long.TryParse(idNumber.Remove(17), out n) == false

                || n < Math.Pow(10, 16) || long.TryParse(idNumber.Replace('x', '0').Replace('X', '0'), out n) == false)

            {

                return false;//数字验证  

            }

            string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";

            if (address.IndexOf(idNumber.Remove(2)) == -1)

            {

                return false;//省份验证  

            }

            string birth = idNumber.Substring(6, 8).Insert(6, "-").Insert(4, "-");

            DateTime time = new DateTime();

            if (DateTime.TryParse(birth, out time) == false)

            {

                return false;//生日验证  

            }

            string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');

            string[] Wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');

            char[] Ai = idNumber.Remove(17).ToCharArray();

            int sum = 0;

            for (int i = 0; i < 17; i++)

            {

                sum += int.Parse(Wi[i]) * int.Parse(Ai[i].ToString());

            }

            int y = -1;

            Math.DivRem(sum, 11, out y);

            if (arrVarifyCode[y] != idNumber.Substring(17, 1).ToLower())

            {

                return false;//校验码验证  

            }

            return true;//符合GB11643-1999标准  

        }
    }
}

