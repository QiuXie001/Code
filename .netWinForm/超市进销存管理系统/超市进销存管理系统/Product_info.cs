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
    public partial class Product_info : Form
    {
        public Product_info()
        {
            InitializeComponent();
        }
        string SendID;
        public Product_info(string user)
        {
            InitializeComponent();
            SendID = user;
        }
        private void exit_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage(SendID);
            homepage.Show();
            this.Hide();
        }
        string sql = "select " +
            "商品号=ProductID ," +
            "商品名=ProductName ," +
            "供应商 = SupplierID ," +
            "商品类别 = TypeID ," +
            "库存 = ProductCount  ," +
            "售价=Price  ," +
            "进价=Carry    " +
            "from s_product";
        List<string> sqlList;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable table = new DataTable();
        private void Product_info_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            toolStripStatusLabel3.Text = "当前操作员：" + SendID;
            toolStripStatusLabel5.Text = "登录时间：" + DateTime.Now;
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
            timer1.Enabled = true;
            table = DBHelper.ExecuteAdapter(sql);
            dataGridView1.DataSource = table;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = 0;
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                string TypeID = "null";
                string id = this.dataGridView1.SelectedCells[0].Value.ToString();
                string sql1 = "select " +
                    "ProductID ," +
                    "ProductName ," +
                    "SupplierID ," +
                    "TypeID ," +
                    "ProductNumber ," +
                    "Carry ," +
                    "Price ," +
                    "ProductCount ," +
                    "ProductOrder ," +
                    "ProductStop " +
                    "from s_product " +
                    "where ProductID ='" + id + "'";
                SqlConnection conn, Conn;
                SqlDataReader read1 = DBHelper.Obtain(sql1, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                while (read1.Read())
                {
                    ID.Text = read1["ProductID"].ToString();
                    TypeID = read1["TypeID"].ToString();
                    Product_Name.Text = read1["ProductName"].ToString(); //如上
                    Supplier_ID.Text = read1["SupplierID"].ToString();
                    Stop.Text = read1["ProductStop"].ToString();
                    Number.Text = read1["ProductNumber"].ToString();
                    Price.Text = read1["Price"].ToString();
                    Carry.Text = read1["Carry"].ToString();
                    Inventory.Text = read1["ProductNumber"].ToString();
                }
                if (conn != null) //判断con不为空
                {
                    conn.Close();
                }
                string sql2 = "select TypeName  " +
                    "from s_type " +
                    "where TypeID  ='" + TypeID + "'";
                
                SqlDataReader read2 = DBHelper.Obtain(sql2, out Conn);
                while (read2.Read())
                {
                    Type.Text = read2["TypeName"].ToString();
                }
                if (Conn != null) //判断con不为空
                {
                    Conn.Close();
                }

                n = 1;
            }
            if (n > 0)
                MessageBox.Show("选中成功");
        }
    }
}
