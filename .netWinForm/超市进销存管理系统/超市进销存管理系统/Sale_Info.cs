using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 超市进销存管理系统
{
    public partial class Sale_Info : Form
    {
        public Sale_Info()
        {
            InitializeComponent();
        }
        string SendID; 
        public Sale_Info(string user)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
        }

        private void Inventory_search_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            toolStripStatusLabel3.Text = "当前操作员：" + SendID;
            toolStripStatusLabel5.Text = "登录时间：" + DateTime.Now;
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
            timer1.Enabled = true;
            string sql = "select " +
                "ROW_NUMBER () OVER ( ORDER BY sum(Number) DESC ) \"排名\"," +
                "商品ID = s_product.ProductID ," +
                "商品名称 = s_product.ProductName ," +
                "销量 = sum(Number) " +
                "from s_product inner join detail on s_product.ProductID = detail.ProductID " +
                "group by s_product.ProductID,s_product.ProductName " +
                "order by sum(Number) desc";
            DataTable table = DBHelper.ExecuteAdapter(sql);
            dataGridView1.DataSource = table;
        }


    }
}
