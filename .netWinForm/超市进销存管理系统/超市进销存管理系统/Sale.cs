using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 超市进销存管理系统
{
    public partial class Sale : Form
    {
        public Sale()
        {
            InitializeComponent();
        }
        string SendID; 
        public Sale(string user)
        {
            InitializeComponent();
            SendID = user;
        }
        string sql;
        List<string> sqlList;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable table = new DataTable();
        string str;
        int number = 0;
        int num = 1;
        double payable=0.00;
        private void exit_Click(object sender, EventArgs e)
        {
            if (DBHelper.Receipt_Exist() == 0)
            {
                str = "请在确认当前订单已导出后退出";
                DialogResult res = MessageBox.Show(str, "提示", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    Homepage homepage = new Homepage(SendID);
                    homepage.Show();
                    this.Hide();
                }
            }
            else 
            {
                Homepage homepage = new Homepage(SendID);
                homepage.Show();
                this.Hide();
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
        }
        public void reFresh()
        {
            table.Clear();
            sql = "select " +
            "产品编号=ProductID," +
            "产品名称=ProductName," +
            "售价=Price," +
            "数量 = Number," +
            "折扣 = Discount " +
            "from receipt ";
            str = "￥";
            table = DBHelper.ExecuteAdapter(sql);
            dataGridView1.DataSource = table;
            Number.Text = number.ToString();
            Payable.Text = payable.ToString() + str;
        }
        private void Sale_Load(object sender, EventArgs e)
        {
            sql = "delete from receipt";
            DBHelper.ExecuteAdapter(sql);
            Operator.Text = SendID;
            toolStripStatusLabel3.Text = "当前操作员：" + SendID;
            toolStripStatusLabel5.Text = "登录时间：" + DateTime.Now;
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
            timer1.Enabled = true;
            sql = "select " +
            "产品编号=ProductID," +
            "产品名称=ProductName," +
            "售价=Price," +
            "数量 = Number," +
            "折扣 = Discount " +
            "from receipt ";
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = DBHelper.ExecuteAdapter(sql);
            Number.Text = number.ToString();
            str = "￥";
            Payable.Text = payable.ToString() + str;
        }

        private void Select_Click(object sender, EventArgs e)
        {
            string CustomName = "null", CustomID = "null", CustomAddress = "null";
            SqlConnection conn;
            int n = DBHelper.Vip_Exist(Tel.Text);
            if (n == 1)
                MessageBox.Show("该手机号非会员电话,请先注册！");

            else
            {
                sql = ("select CustomID ,CustomName ,CustomAddress ,CustomPhone " +
                    "from s_custom " +
                    "where CustomPhone = '"+ Tel.Text +"'");
                SqlDataReader read = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                while (read.Read())
                {
                    CustomName = read["CustomName"].ToString();
                    CustomID = read["CustomID"].ToString();
                    CustomAddress = read["CustomAddress"].ToString();
                }
                
                str = "索引成功，请确认该会员是否为本人：\n" +
                    "会员姓名：{0}\n" +
                    "会员编号：{1}\n" +
                    "会员地址：{2}\n";
                str = string.Format(str,
                    CustomName,
                    CustomID,
                    CustomAddress
                    );
                if (conn != null) 
                {
                    conn.Close();
                }
                DialogResult res = MessageBox.Show(str,"提示",MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    ID.Text = DateTime.Now.Year.ToString() + 
                        DateTime.Now.Month.ToString().PadLeft(2, '0') +
                        DateTime.Now.Day.ToString().PadLeft(2, '0') +
                        DateTime.Now.Hour.ToString().PadLeft(2, '0') +
                        DateTime.Now.Minute.ToString().PadLeft(2, '0') +
                        DateTime.Now.Second.ToString().PadLeft(2, '0');
                }

            }
        }

        private void Import_Click(object sender, EventArgs e)
        {
            if (Good.Text!="")
            {
                if (ID.Text != "")
                {
                    SqlConnection conn;
                    string CustomID = "null";
                    sql = ("select CustomID ,CustomName ,CustomAddress ,CustomPhone " +
                            "from s_custom " +
                            "where CustomPhone = '" + Tel.Text + "'");
                    SqlDataReader read = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                    while (read.Read())
                    {
                        CustomID = read["CustomID"].ToString();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    string ProductID = Good.Text;
                    string ProductName = "null";
                    string ProductCount = "null";
                    string Price = "null";
                    float Discount = 1;
                    sql = ("select ProductID  ,ProductName  ,SupplierID  ,TypeID , ProductNumber ,Price ,Price ,ProductCount ,ProductOrder " +
                            "from s_product " +
                            "where ProductID  = '" + ProductID + "'");
                    read = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                    while (read.Read())
                    {
                        ProductID = read["ProductID"].ToString();
                        ProductName = read["ProductName"].ToString();
                        ProductCount = read["ProductCount"].ToString();
                        Price = read["Price"].ToString();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }

                    if (ProductCount == "0") //判断库存是否为零
                    {
                        MessageBox.Show("库存不足，请联系采购部门管理员");
                    }
                    else 
                    {
                        string sql1 = "select count(*) from s_product where ProductID  = '" + Good.Text + "'";
                        if (DBHelper.ExecuteScale(sql1).ToString() == "1")
                        {
                            if (DBHelper.Good_Exist(Good.Text) == 1)
                            {
                                num = 1;
                                sql = ("insert into receipt" +
                                    " values('{0}','{1}','{2}','{3}','{4}',{5},{6},{7})");
                                sql = string.Format(sql,
                                ID.Text,
                                CustomID,
                                SendID,
                                ProductID,
                                ProductName,
                                Price,
                                num,
                                Discount
                                 );
                                DBHelper.ExecuteAdapter(sql);
                                number++;
                                payable += Convert.ToDouble(Price);

                                sql = "update s_product set " +//减少库存
                               "ProductCount =ProductCount - 1 " +
                               "where ProductID ='" + ProductID + "'";
                                DBHelper.ExecuteAdapter(sql);

                                reFresh();
                            }
                            else if (DBHelper.Good_Exist(Good.Text) == 0)
                            {
                                sql = ("update receipt set " +
                                "RecID = '" + ID.Text + "'," +
                                "CustomID ='" + CustomID + "'," +
                                "OperatorID  = '" + SendID + "'," +
                                "ProductID ='" + ProductID + "'," +
                                "ProductName ='" + ProductName + "'," +
                                "Price =" + Price + "," +
                                "Number =" + ++num + "," +
                                "Discount =" + Discount + "" +
                                "where RecID ='" + ID.Text + "' " +
                                "and ProductID ='" + ProductID + "'");
                                DBHelper.ExecuteAdapter(sql);
                                payable += Convert.ToDouble(Price);

                                sql = "update s_product set " +//减少库存
                                "ProductCount =ProductCount - 1 " +
                                "where ProductID ='" + ProductID + "'";
                                DBHelper.ExecuteAdapter(sql);

                                reFresh();
                            }
                        }
                        else
                            MessageBox.Show("商品不存在");
                    }
                }
            }
            
        }

        private void Export_Click(object sender, EventArgs e)
        {
            if (ID.Text != "")
            {
                if (this.dataGridView1.SelectedCells.Count > 0 && this.dataGridView1.SelectedCells[0].Value != null) 
                {
                    string ProductID = Good.Text;
                    SqlConnection conn;
                    SqlDataReader read = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                    sql = ("select ProductID  ,ProductName  ,SupplierID  ,TypeID , ProductNumber ,Price ,Price ,ProductCount ,ProductOrder " +
                                "from s_product " +
                                "where ProductID  = '" + ProductID + "'");
                    read = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                    while (read.Read())
                    {
                        ProductID = read["ProductID"].ToString();
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    int n = 0;
                    str = "请确认导出当前单据";
                    DialogResult res = MessageBox.Show(str, "提示", MessageBoxButtons.OKCancel);
                    if (res == DialogResult.OK)
                    {
                        sql = "insert into detail select * from receipt";
                        n++;
                        number = 0;
                        DBHelper.ExecuteAdapter(sql);
                        reFresh();
                    }
                    if (n > 0)
                    {
                        if(Paidin.Text=="")
                        {
                            MessageBox.Show("请输入实收！");
                        }
                        else
                        {
                            double paidin = Convert.ToDouble(Paidin.Text);
                            double payable_ = payable;
                            payable = 0;
                            str = "请找零："+(paidin - payable_).ToString() + "元";
                            DialogResult resou = MessageBox.Show(str, "提示", MessageBoxButtons.OKCancel);
                            if (resou == DialogResult.OK)
                            {
                                MessageBox.Show("导出成功");
                                Sale sale = new Sale();
                                this.Close();
                                sale.Show();
                            } 
                        }         
                    }
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0 && this.dataGridView1.SelectedCells[0].Value != null)
            {
                string price ="";
                string price_number ="";
                double pri = 0 ;
                double num = 0 ;
                int n = 0;
                string id = this.dataGridView1.SelectedCells[0].Value.ToString();
                sqlList = new List<string>(0);
                int i = 0;
                str = "请确认删除该件商品";
                DialogResult res = MessageBox.Show(str, "提示", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    SqlConnection conn;
                    SqlDataReader read = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                    sql = "select RecID ,CustomID ,OperatorID ,ProductID ,ProductName ,Price ,Number ,Discount " +
                            "from receipt " +
                            "where ProductID  = '" + id + "'";
                    read = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                    while (read.Read())
                    {
                        price = read["Price"].ToString();
                        price_number = read["Number"].ToString();
                        pri = Convert.ToDouble(price);
                        num = Convert.ToDouble(price_number);
                    }
                    if (conn != null)
                    {
                        conn.Close();
                    }

                    sql = "delete from receipt where ProductID ='" + id + "'";
                    DBHelper.ExecuteAdapter(sql);
                    n++;
                    number--;
                    payable = payable - (pri * num);
                    reFresh();
                }
                if (n > 0)
                {
                    MessageBox.Show("删除成功");
                    string Return = "update s_product set ProductCount=ProductCount+'"+ num +"' where ProductID='" + id + "'";
                    DBHelper.ExecuteNonQuery(Return);
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            str = "是否清除当前页面信息";
            DialogResult res = MessageBox.Show(str, "提示", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                Sale sale = new Sale();
                this.Close();
                sale.Show();
            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        //功能未实现
        //private void print_Click(object sender, EventArgs e)
        //{
        //    sql = "select RecID ,CustomID ,OperatorID ,ProductID ,ProductName ,Price ,Number ,Discount " +
        //                    "from receipt " +
        //                    "where ProductID  = '" + ID.Text + "'";
        //    string connString = DBHelper.getConnstr();
        //    SqlConnection connection = new SqlConnection(connString);
        //    SqlCommand command = new SqlCommand(sql, connection);
        //    connection.Open();
        //    int ProductName;
        //    string Price = "";
        //    string Number = "";
        //    SqlDataReader dataReader = command.ExecuteReader();
        //    while (dataReader.Read())
        //    {
        //        ProductName = (int)dataReader["ProductName"];
        //        Price = (string)dataReader["Price"];
        //        Number = (string)dataReader["Number"];
        //        Console.WriteLine("{0},{1},{2}", ProductName, Number, Price);
        //        Console.WriteLine("1111");
        //    }
        //    dataReader.Close();
        //    connection.Close();
        //}
    }
}
