using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace 超市进销存管理系统
{
    public partial class sales : Form
    {
        public sales()
        {
            InitializeComponent();
        }
        public sales(string SendID)
        {
            InitializeComponent();

            string ordernumber = System.DateTime.Now.ToString();
            label6.Text = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Day.ToString().PadLeft(2,'0') + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0');
            label8.Text = SendID;
        }
        private void sales_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            string sql = "select 产品编号=detail.ProductID,产品名称=ProductName,售价=detail.Carry,数量 = Number ,折扣 = Discount from detail join s_product on detail.productID=s_product.productIDselect 产品编号=detail.ProductID,产品名称=ProductName,售价=detail.Carry,数量 = Number ,折扣 = Discount from detail join s_product on detail.productID=s_product.productID";
            dataGridView1.DataSource = DBHelper.ExecuteAdapter(sql);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int num;
            string sql= "insert into detail values(" +
                " ,)"
        }
        public void reFresh()
        {
            string sql = "select 产品编号=detail.ProductID,产品名称=ProductName,售价=detail.Carry,数量 = Number ,折扣 = Discount from detail join s_product on detail.productID=s_product.productID";
            dataGridView1.DataSource = DBHelper.ExecuteAdapter(sql);
        }

    }
}
