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
    public partial class Refund : Form
    {
        public Refund()
        {
            InitializeComponent();
        }
        string SendID;
        public Refund(string user)
        {
            InitializeComponent();
            SendID = user;
        }
        string sql;
        List<string> sqlList;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable table = new DataTable();
        string str;
        private void exit_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage(SendID);
            homepage.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
        }
        int n = 0;
        public void reFresh()
        {
            table.Clear();
            sql = "select " +
                "订单编号=RecID," +
            "产品编号=ProductID," +
            "产品名称=ProductName," +
            "售价=Price," +
            "数量 = Number," +
            "折扣 = Discount " +
            "from detail "; 
            if(n==1)
            {
                sql=sql+"where RecID = '"+ RecID.Text + "'";
            }
            table = DBHelper.ExecuteAdapter(sql);
            dataGridView1.DataSource = table;
        }
        private void Refund_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            toolStripStatusLabel3.Text = "当前操作员：" + SendID;
            toolStripStatusLabel5.Text = "登录时间：" + DateTime.Now;
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
            timer1.Enabled = true;
            n = 0;
            reFresh();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0 && this.dataGridView1.SelectedRows[0].Cells[1].Value !=null)
            {
                string count ="";
                string count2 = "";
                str = "请确认需要退货";
                DialogResult res = MessageBox.Show(str, "提示", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    sql = "select " +
                        "ProductCount " +
                        "from s_product " +
                        "where ProductID ='" + this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "'";
                    SqlConnection Conn;
                    SqlDataReader read = DBHelper.Obtain(sql, out Conn);
                    while (read.Read())
                    {
                        count = read["ProductCount"].ToString();
                    }
                    if (Conn != null) //判断con不为空
                    {
                        Conn.Close();
                    }
                    //获取原先数量
                    sql = "select " +
                        "Number  " +
                        "from detail " +
                        "where ProductID ='" + this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "'";
                    read = DBHelper.Obtain(sql, out Conn);
                    while (read.Read())
                    {
                        count2 = read["Number"].ToString();
                    }
                    if (Conn != null) //判断con不为空
                    {
                        Conn.Close();
                    }
                    int number = int.Parse(count) + int.Parse(count2);
                    //获取退货数量
                    sql = "update s_product set " +
                        "ProductCount = '" + number + "'" +
                        "where ProductID ='" + this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "'";
                    DBHelper.ExecuteAdapter(sql);

                    sql = "delete from detail where  RecID = '"+ RecID.Text + "'and ProductID ='" + this.dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "'";
                    table = DBHelper.ExecuteAdapter(sql);
                    reFresh();
                }
            }
            else
            {
                MessageBox.Show("请选中需要退货的商品");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (RecID.Text == "")
            {
                n = 0;
                reFresh();
            }
            else
            {
                n = 1;
                reFresh();
            }

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.dataGridView1.SelectedCells.Count > 0 && this.dataGridView1.SelectedCells[0].Value != null)
            {
                this.RecID.Text = this.dataGridView1.SelectedCells[0].Value.ToString();
                MessageBox.Show("选中成功");
            }
            
        }
    }
}
