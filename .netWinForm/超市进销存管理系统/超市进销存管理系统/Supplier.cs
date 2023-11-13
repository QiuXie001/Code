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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }
        string SendID;
        public Supplier(string user)
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
                "公司编号=SupplierID ," +
                "公司名称=SupplierCompany ," +
                "联系人姓名=SupplierName ," +
                "联系人职务=SupplierTittle ," +
                "联系人电话=SupplierPhone   " +
                "from s_supplier";
        List<string> sqlList;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable table = new DataTable();

        private void Supplier_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            toolStripStatusLabel3.Text = "当前操作员：" + SendID;
            toolStripStatusLabel5.Text = "登录时间：" + DateTime.Now;
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
            timer1.Enabled = true;
            table = DBHelper.ExecuteAdapter(sql);
            dataGridView1.DataSource = table;
            string[] bound = { "公司编号", "公司名称", "联系人姓名", "联系人电话" }; //添加字符串数据
            SearchCombobox.ComboBox.Items.AddRange(bound);               //将字符串数组添加至comboBox2.Items属性中
            SearchCombobox.ComboBox.Text = "=请选择=";
            //填充查询combobox
        }
        public void reFresh()
        {
            table.Clear();
            sql = "select " +
                "公司编号=SupplierID ," +
                "公司名称=SupplierCompany ," +
                "联系人姓名=SupplierName ," +
                "联系人职务=SupplierTittle ," +
                "联系人电话=SupplierPhone   " +
                "from s_supplier";
            table = DBHelper.ExecuteAdapter(sql);
            dataGridView1.DataSource = table;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = 0;
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                string id = this.dataGridView1.SelectedCells[0].Value.ToString();
                SqlConnection conn, Conn;
                sql = "select " +
                    "SupplierID," +
                    "SupplierCompany," +
                    "SupplierName ," +
                    "SupplierTittle ," +
                    "SupplierAddress ," +
                    "SupplierPostcode ," +
                    "SupplierPhone ," +
                    "SupplierFax ," +
                    "SupplierHomePage ," +
                    "SupplierStop " +
                    "from  s_supplier " +
                    "where SupplierID ='" + id + "'";
                SqlDataReader read = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                
                while (read.Read())
                {
                    id = read["SupplierID"].ToString();
                    ID.Text = read["SupplierID"].ToString(); //如上
                    Com_Name.Text = read["SupplierCompany"].ToString();
                    Con_Name.Text = read["SupplierName"].ToString();
                    Title.Text = read["SupplierTittle"].ToString();
                    Tel.Text = read["SupplierPhone"].ToString();
                    Fax.Text = read["SupplierFax"].ToString();
                    Address.Text = read["SupplierAddress"].ToString();
                    Index.Text = read["SupplierHomePage"].ToString();
                    PostCode.Text = read["SupplierPostcode"].ToString();
                }
                if (conn != null) //判断con不为空
                {
                    conn.Close();

                }
                n = 1;
            }
            if (n > 0)
                MessageBox.Show("选中成功");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = 0;
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                string id = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                SqlConnection conn, Conn;
                sql = "select " +
                    "SupplierID," +
                    "SupplierCompany," +
                    "SupplierName ," +
                    "SupplierTittle ," +
                    "SupplierAddress ," +
                    "SupplierPostcode ," +
                    "SupplierPhone ," +
                    "SupplierFax ," +
                    "SupplierHomePage ," +
                    "SupplierStop " +
                    "from  s_supplier " +
                    "where SupplierID ='" + id + "'";
                SqlDataReader read = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型

                while (read.Read())
                {
                    id = read["SupplierID"].ToString();
                    ID.Text = read["SupplierID"].ToString(); //如上
                    Com_Name.Text = read["SupplierCompany"].ToString();
                    Con_Name.Text = read["SupplierName"].ToString();
                    Title.Text = read["SupplierTittle"].ToString();
                    Tel.Text = read["SupplierPhone"].ToString();
                    Fax.Text = read["SupplierFax"].ToString();
                    Address.Text = read["SupplierAddress"].ToString();
                    Index.Text = read["SupplierHomePage"].ToString();
                    PostCode.Text = read["SupplierPostcode"].ToString();
                }
                if (conn != null) //判断con不为空
                {
                    conn.Close();

                }
                n = 1;
            }
            if (n > 0)
                MessageBox.Show("选中成功");
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            this.Close();
            supplier.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (ID.Text!=""&&DBHelper.IsHandset(Tel.Text))
            {
                string id = ID.Text;
                sqlList = new List<string>(0);
                int n = 0;
                if (DBHelper.Com_ID_Exist(ID.Text) == 1)
                {
                    MessageBox.Show("公司编号重复");
                }
                else
                {
                    sqlList = new List<string>(0);
                    sql = ("insert into s_supplier" +
                        " values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9})");
                    sql = string.Format(sql,
                        ID.Text,
                        Com_Name.Text,
                        Con_Name.Text,
                        Title.Text,
                        Address.Text,
                        PostCode.Text,
                        Tel.Text,
                        Fax.Text,
                        Index.Text,
                        1);
                    sqlList.Add(sql);
                    DBHelper.ExecuteNonQueryTransaction(sqlList);
                    n = 1;
                }
                if (n > 0)
                {
                    MessageBox.Show("插入成功");

                    reFresh();
                }
            }
            else MessageBox.Show("格式错误，请检查后重试");
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (ID.Text != "")
            {
                int n = 0;
                string id = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); ;
                sqlList = new List<string>(0);
                sqlList.Add("delete from s_supplier where SupplierID  ='" + id + "'");
                DBHelper.ExecuteNonQueryTransaction(sqlList);
                n++;
                reFresh();

                if (n > 0)
                {
                    MessageBox.Show("删除成功");
                    reFresh();
                }
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (ID.Text != ""&&DBHelper.IsHandset(Tel.Text))
            {
                int n = 0;
                string id = ID.Text;
                sqlList = new List<string>(0);
                sql = "update s_supplier set " +
                            "SupplierID  = '" + ID.Text + "'," +
                            "SupplierCompany  = '" + Com_Name.Text + "'," +
                            "SupplierName  = '" + Con_Name.Text + "'," +
                            "SupplierTittle  = '" + Title.Text + "'," +
                            "SupplierAddress  =  '" + Address.Text + "' ," +
                            "SupplierPostcode  = '" + PostCode.Text + "'," +
                            "SupplierPhone  = '" + Tel.Text + "'," +
                            "SupplierFax  = '" + Fax.Text + "'," +
                            "SupplierHomePage  = '" + Index.Text + "'," +
                            "SupplierStop  = 1 " +
                            "where SupplierID ='" + id + "'";
                sqlList.Add(sql);
                if (true)
                {
                    DBHelper.ExecuteNonQueryTransaction(sqlList);
                    n++;
                }
                reFresh();

                if (n > 0)
                    MessageBox.Show("更改成功");
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (SearchCombobox.Text == "公司编号")//ID查询
            {
                sql = "select " +
                "公司编号=SupplierID ," +
                "公司名称=SupplierCompany ," +
                "联系人姓名=SupplierName ," +
                "联系人职务=SupplierTittle ," +
                "联系人电话=SupplierPhone   " +
                "from s_supplier" +
                "where SupplierID like '%" + toolStripTextBox1.Text + "%'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            if (SearchCombobox.Text == "公司名称")//ComName查询
            {
                sql = "select " +
                "公司编号=SupplierID ," +
                "公司名称=SupplierCompany ," +
                "联系人姓名=SupplierName ," +
                "联系人职务=SupplierTittle ," +
                "联系人电话=SupplierPhone   " +
                "from s_supplier" +
                "where SupplierCompany like '%" + toolStripTextBox1.Text + "%'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            if (SearchCombobox.Text == "联系人姓名")//ConName查询
            {
                sql = "select " +
                "公司编号=SupplierID ," +
                "公司名称=SupplierCompany ," +
                "联系人姓名=SupplierName ," +
                "联系人职务=SupplierTittle ," +
                "联系人电话=SupplierPhone   " +
                "from s_supplier" +
                "where SupplierName like '%" + toolStripTextBox1.Text + "%'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            if (SearchCombobox.Text == "联系人电话")//TEL查询
            {
                sql = "select " +
                "公司编号=SupplierID ," +
                "公司名称=SupplierCompany ," +
                "联系人姓名=SupplierName ," +
                "联系人职务=SupplierTittle ," +
                "联系人电话=SupplierPhone   " +
                "from s_supplier" +
                "where SupplierPhone = '" + toolStripTextBox1.Text + "'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
        }
    }
}
