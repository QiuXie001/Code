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
    public partial class Custom : Form
    {
        string SendID;
        public Custom()
        {
            InitializeComponent();
        }
        public Custom(string user)
        {
            InitializeComponent();
            SendID = user;
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
        string str = "";
        public void reFresh()
        {
            table.Clear();
            sql = "select " +
                "客户编号=CustomID  ," +
                "客户公司=CustomCompany  ," +
                "客户姓名=CustomName  ," +
                "职务=CustomTitle ," +
                "地址=CustomAddress ," +
                "邮编=CustomPostCode ," +
                "电话=CustomPhone " +
                "from s_custom";
            table = DBHelper.ExecuteAdapter(sql);
            dataGridView1.DataSource = table;
            SearchCombobox.ComboBox.Text = "=请选择=";
        }

        private void Custom_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            toolStripStatusLabel3.Text = "当前操作员：" + SendID;
            toolStripStatusLabel5.Text = "登录时间：" + DateTime.Now;
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
            timer1.Enabled = true;
            sql = "select " +
                "客户编号=CustomID  ," +
                "客户公司=CustomCompany  ," +
                "客户姓名=CustomName  ," +
                "职务=CustomTitle ," +
                "地址=CustomAddress ," +
                "邮编=CustomPostCode ," +
                "电话=CustomPhone " +
                "from s_custom";
            table = DBHelper.ExecuteAdapter(sql);
            dataGridView1.DataSource = table;
            string[] bound = { "客户ID", "客户公司", "客户姓名", "电话" }; //添加字符串数据
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
                string id = this.dataGridView1.SelectedCells[0].Value.ToString();
                sql = "select " +
                    "CustomID," +
                    "CustomCompany," +
                    "CustomName," +
                    "CustomTitle," +
                    "CustomAddress," +
                    "CustomPostCode," +
                    "CustomPhone " +
                    "from s_custom " +
                    "where CustomID='" + id + "'";
                SqlConnection conn;
                SqlDataReader read = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型

                while (read.Read())
                {
                    ID.Text = read["CustomID"].ToString();
                    Company.Text = read["CustomCompany"].ToString(); //如上
                    cus_Name.Text = read["CustomName"].ToString(); 
                    Title.Text = read["CustomTitle"].ToString(); 
                    Address.Text = read["CustomAddress"].ToString(); 
                    PostCode.Text = read["CustomPostCode"].ToString(); 
                    Phone.Text = read["CustomPhone"].ToString();
                    str = "选中成功";
                    MessageBox.Show(str);
                }
                if (conn != null) //判断con不为空
                {
                    conn.Close();
                }
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Custom custom = new Custom(SendID);
            custom.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (ID.Text != "")
            {
                SqlConnection Conn;
                string id = ID.Text;
                sqlList = new List<string>(0);
                int n = 0;
                if (DBHelper.Custom_ID_Exist(ID.Text) == 0)
                {
                    MessageBox.Show("会员ID已存在");
                }
                else
                {
                    sql = ("insert into s_custom" +
                        " values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')");
                    sql = string.Format(sql,
                        ID.Text,
                        Company.Text,
                        cus_Name.Text,
                        Title.Text,
                        Address.Text,
                        PostCode.Text,
                        Phone.Text);
                    n = 1;
                    DBHelper.ExecuteAdapter(sql);
                }
                if (n > 0)
                {
                    MessageBox.Show("会员注册成功");
                    reFresh();
                }
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (ID.Text != "")
            {
                string id = this.dataGridView1.SelectedCells[0].Value.ToString();
                sql = "update s_custom set " +
                            "CustomID   = '" + ID.Text + "'," +
                            "CustomCompany   = '" + Company.Text + "'," +
                            "CustomName  = '" + cus_Name.Text + "'," +
                            "CustomTitle  = '" + Title.Text + "'," +
                            "CustomAddress  = '" + Address.Text + "'," +
                            "CustomPostCode  = " + PostCode.Text + "," +
                            "CustomPhone  = " + Phone.Text + "" +
                            "where CustomID ='" + id + "'";
                DBHelper.ExecuteAdapter(sql);
                MessageBox.Show("修改成功");
                reFresh();
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (ID.Text != "")
            {
                if (this.dataGridView1.SelectedCells[0].Value != null)
                {
                    int n = 0;
                    string id = ID.Text;
                    sql = "delete from s_custom where CustomID = '" + id + "'";
                    n++;
                    DBHelper.ExecuteAdapter(sql);
                    reFresh();

                    if (n > 0)
                    {
                        MessageBox.Show("删除成功");
                    }
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (SearchCombobox.Text == "客户ID")//
            {
                sql = "select " +
                "客户编号=CustomID  ," +
                "客户公司=CustomCompany  ," +
                "客户姓名=CustomName  ," +
                "职务=CustomTitle ," +
                "地址=CustomAddress ," +
                "邮编=CustomPostCode ," +
                "电话=CustomPhone " +
                "from s_custom " +
                "where CustomID = '" + toolStripTextBox1.Text + "'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "客户公司")//
            {
                sql = "select " +
                "客户编号=CustomID  ," +
                "客户公司=CustomCompany  ," +
                "客户姓名=CustomName  ," +
                "职务=CustomTitle ," +
                "地址=CustomAddress ," +
                "邮编=CustomPostCode ," +
                "电话=CustomPhone " +
                "from s_custom " +
                "where CustomCompany like '%" + toolStripTextBox1.Text + "%'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "客户姓名")//
            {
                sql = "select " +
                "客户编号=CustomID  ," +
                "客户公司=CustomCompany  ," +
                "客户姓名=CustomName  ," +
                "职务=CustomTitle ," +
                "地址=CustomAddress ," +
                "邮编=CustomPostCode ," +
                "电话=CustomPhone " +
                "from s_custom " +
                "where CustomName like '%" + toolStripTextBox1.Text + "%'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "客户电话")//
            {
                sql = "select " +
                "客户编号=CustomID  ," +
                "客户公司=CustomCompany  ," +
                "客户姓名=CustomName  ," +
                "职务=CustomTitle ," +
                "地址=CustomAddress ," +
                "邮编=CustomPostCode ," +
                "电话=CustomPhone " +
                "from s_custom " +
                "where CustomPhone = '" + toolStripTextBox1.Text + "'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
        }
    }
}
