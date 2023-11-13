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
    public partial class Product_manage : Form
    {
        public Product_manage()
        {
            InitializeComponent();
        }
        string SendID;
        public Product_manage(string user)
        {
            InitializeComponent();
            SendID = user;
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
        public void reFresh()
        {
            table.Clear();
            sql = "select " +
            "商品号=ProductID ," +
            "商品名=ProductName ," +
            "供应商 = SupplierID ," +
            "商品类别 = TypeID ," +
            "库存 = ProductCount ," +
            "售价=Price  ," +
            "进价=Carry    " +
            "from s_product";
            table = DBHelper.ExecuteAdapter(sql);
            dataGridView1.DataSource = table;
            SearchCombobox.ComboBox.Text = "=请选择=";

        }
        private void Product_search_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            toolStripStatusLabel3.Text = "当前操作员：" + SendID;
            toolStripStatusLabel5.Text = "登录时间：" + DateTime.Now;
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
            timer1.Enabled = true;
            table = DBHelper.ExecuteAdapter(sql);
            dataGridView1.DataSource = table;
            string[] bound = { "产品ID", "产品名称", "类别", "供货商", "售价(高于)", "售价(低于)",  "利润率（低于）" , "利润率（高于）" }; //添加字符串数据
            SearchCombobox.ComboBox.Items.AddRange(bound);               //将字符串数组添加至comboBox2.Items属性中
            SearchCombobox.ComboBox.Text = "=请选择=";
            //填充查询combobox
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage(SendID);
            homepage.Show();
            this.Hide();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = 0;
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                string TypeID = "null";
                string id = this.dataGridView1.SelectedCells[0].Value.ToString();
                sql = "select " +
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
                SqlDataReader read1 = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                while (read1.Read())
                {
                    ID.Text = read1["ProductID"].ToString();
                    TypeID = read1["TypeID"].ToString();
                    Product_Name.Text = read1["ProductName"].ToString(); //如上
                    Supplier_ID.Text = read1["SupplierID"].ToString();
                    Number.Text = read1["ProductNumber"].ToString();
                    Price.Text = read1["Price"].ToString();
                    Carry.Text = read1["Carry"].ToString();
                    Inventory.Text = read1["ProductCount"].ToString();
                }
                if (conn != null) //判断con不为空
                {
                    conn.Close();
                }
                sql = "select TypeName  " +
                    "from s_type " +
                    "where TypeID  ='" + TypeID + "'";

                SqlDataReader read2 = DBHelper.Obtain(sql, out Conn);
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

        private void But_Click(object sender, EventArgs e)
        {
            if (Order.Text!="")
            {
                SqlConnection Conn;
                string id = this.dataGridView1.SelectedCells[0].Value.ToString();
                string TypeID = "";
                string sql2 = "select TypeID  " +
                    "from s_type " +
                    "where TypeName  ='" + Type.Text + "'";

                SqlDataReader read2 = DBHelper.Obtain(sql2, out Conn);
                while (read2.Read())
                {
                    TypeID = read2["TypeID"].ToString();
                }
                if (Conn != null) //判断con不为空
                {
                    Conn.Close();
                }
                int count = int.Parse(Inventory.Text) + int.Parse(Order.Text);
                sql = "update s_product set " +
                        "ProductID  = '" + ID.Text + "'," +
                        "ProductName  = '" + Product_Name.Text + "'," +
                        "SupplierID = '" + Supplier_ID.Text + "'," +
                        "TypeID = '" + TypeID + "'," +
                        "ProductNumber = '" + Number.Text + "'," +
                        "Carry = " + Carry.Text + "," +
                        "Price = " + Price.Text + "," +
                        "ProductCount = '" + count + "'," +
                        "ProductOrder = " + "0" + "," +
                        "ProductStop = " + "1" + " " +
                        "where ProductID ='" + id + "'";
                DBHelper.ExecuteAdapter(sql);
                Order.Text = "";
                sql = "select ProductCount  " +
                    "from s_product " +
                    "where ProductID  ='" + ID.Text + "'";

                read2 = DBHelper.Obtain(sql, out Conn);
                while (read2.Read())
                {
                    Inventory.Text = read2["ProductCount"].ToString();
                }
                if (Conn != null) //判断con不为空
                {
                    Conn.Close();
                }
                MessageBox.Show("订购成功");
                reFresh();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (ID.Text != "")
            {
                SqlConnection Conn;
                string TypeID = "";
                string sql2 = "select TypeID  " +
                    "from s_type " +
                    "where TypeName  ='" + Type.Text + "'";

                SqlDataReader read2 = DBHelper.Obtain(sql2, out Conn);
                while (read2.Read())
                {
                    TypeID = read2["TypeID"].ToString();
                }
                string id = ID.Text;
                sqlList = new List<string>(0);
                int n = 0;
                if (DBHelper.Product_ID_Exist(ID.Text) == 0)
                {
                    MessageBox.Show("商品ID已存在");
                }
                else
                {
                    sqlList = new List<string>(0);
                    sql = ("insert into s_product" +
                        " values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},'{9}')");
                    sql = string.Format(sql,
                        ID.Text,
                        Product_Name.Text,
                        Supplier_ID.Text,
                        TypeID,
                        Number.Text,
                        Carry.Text,
                        Price.Text,
                        0,
                        0,
                        1);
                    n = 1;
                    DBHelper.ExecuteAdapter(sql);
                }
                if (n > 0)
                {
                    MessageBox.Show("插入成功");
                    reFresh();
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (ID.Text != "")
            {
                int n = 0;
                string id = ID.Text;
                sql = "delete from s_product where ProductID = '" + id + "'";
                n++;
                DBHelper.ExecuteAdapter(sql);
                reFresh();

                if (n > 0)
                {
                    MessageBox.Show("删除成功");
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Product_manage product_search = new Product_manage(SendID);
            product_search.Show();
            this.Hide();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (ID.Text != "")
            {
                string id = this.dataGridView1.SelectedCells[0].Value.ToString();
                SqlConnection Conn;
                string TypeID = "";
                string sql2 = "select TypeID  " +
                    "from s_type " +
                    "where TypeName  ='" + Type.Text + "'";

                SqlDataReader read2 = DBHelper.Obtain(sql2, out Conn);
                while (read2.Read())
                {
                    TypeID = read2["TypeID"].ToString();
                }
                sql = "update s_product set " +
                            "ProductID  = '" + ID.Text + "'," +
                            "ProductName  = '" + Product_Name.Text + "'," +
                            "SupplierID = '" + Supplier_ID.Text + "'," +
                            "TypeID = '" + TypeID + "'," +
                            "ProductNumber = '" + Number.Text + "'," +
                            "Carry = " + Carry.Text + "," +
                            "Price = " + Price.Text + "," +
                            "ProductCount = '" + Inventory.Text + "'," +
                            "ProductOrder = " + "0" + "," +
                            "ProductStop = " + "1" + " " +
                            "where ProductID ='" + id + "'";
                DBHelper.ExecuteAdapter(sql);
                MessageBox.Show("修改成功");
                reFresh();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (SearchCombobox.Text == "产品名称")//产品名称查询
            {
                sql = "select " +
                "商品号=ProductID ," +
                "商品名=ProductName ," +
                "供应商 = SupplierID ," +
                "商品类别 = TypeID ," +
                "库存 = ProductCount ," +
                "售价=Price  ," +
                "进价=Carry    " +
                "from s_product " +
                "where ProductName like '%" + toolStripTextBox1.Text + "%'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "产品ID")//产品ID查询
            {
                sql = "select " +
                "商品号=ProductID ," +
                "商品名=ProductName ," +
                "供应商 = SupplierID ," +
                "商品类别 = TypeID ," +
                "库存 = ProductCount ," +
                "售价=Price  ," +
                "进价=Carry    " +
                "from s_product " +
                "where ProductID like '%" + toolStripTextBox1.Text + "%'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "类别")//类别查询
            {
                SqlConnection Conn;
                string TypeID = "";
                string sql2 = "select TypeID  " +
                    "from s_type " +
                    "where TypeName  like '%" + toolStripTextBox1.Text + "%'";

                SqlDataReader read2 = DBHelper.Obtain(sql2, out Conn);
                while (read2.Read())
                {
                    TypeID = read2["TypeID"].ToString();
                }
                sql = "select " +
                "商品号=ProductID ," +
                "商品名=ProductName ," +
                "供应商 = SupplierID ," +
                "商品类别 = TypeID ," +
                "库存 = ProductCount ," +
                "售价=Price  ," +
                "进价=Carry    " +
                "from s_product " +
                "where TypeID = '" + TypeID + "'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "供货商")//供货商查询
            {
                SqlConnection Conn;
                string SupplierID = "";
                string sql2 = "select SupplierID " +
                    "from s_supplier " +
                    "where SupplierCompany like '%" + toolStripTextBox1.Text + "%'";
                SqlDataReader read2 = DBHelper.Obtain(sql2, out Conn);
                while (read2.Read())
                {
                    SupplierID = read2["SupplierID"].ToString();
                }
                sql = "select " +
                "商品号=ProductID ," +
                "商品名=ProductName ," +
                "供应商 = SupplierID ," +
                "商品类别 = TypeID ," +
                "库存 = ProductCount ," +
                "售价=Price  ," +
                "进价=Carry    " +
                "from s_product " +
                "where SupplierID = '" + SupplierID + "'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "售价(高于)")//售价查询
            {
                sql = "select " +
                "商品号=ProductID ," +
                "商品名=ProductName ," +
                "供应商 = SupplierID ," +
                "商品类别 = TypeID ," +
                "库存 = ProductCount ," +
                "售价=Price  ," +
                "进价=Carry    " +
                "from s_product " +
                "where Price >= '" + toolStripTextBox1.Text + "'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "售价(低于)")//售价查询
            {
                sql = "select " +
                "商品号=ProductID ," +
                "商品名=ProductName ," +
                "供应商 = SupplierID ," +
                "商品类别 = TypeID ," +
                "库存 = ProductCount ," +
                "售价=Price  ," +
                "进价=Carry    " +
                "from s_product " +
                "where Price <= '" + toolStripTextBox1.Text + "'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "利润率（低于）")//利润率查询
            {
                sql = "select " +
                "商品号=ProductID ," +
                "商品名=ProductName ," +
                "供应商 = SupplierID ," +
                "商品类别 = TypeID ," +
                "库存 = ProductCount ," +
                "售价=Price  ," +
                "进价=Carry    " +
                "from s_product " +
                "where (Price-Carry)/Carry <= '" + toolStripTextBox1.Text + "'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "利润率（高于）")//利润率查询
            {
                sql = "select " +
                "商品号=ProductID ," +
                "商品名=ProductName ," +
                "供应商 = SupplierID ," +
                "商品类别 = TypeID ," +
                "库存 = ProductCount ," +
                "售价=Price  ," +
                "进价=Carry    " +
                "from s_product " +
                "where (Price-Carry)/Carry >= '" + toolStripTextBox1.Text + "'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
        }
    }
}
