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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();

        }
        public string SendID; 
        public Homepage(string user)
        {
            InitializeComponent();
            SendID = user;
        }
        private void exit_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "当前操作员："+SendID;
            toolStripStatusLabel5.Text = "登录时间："+DateTime.Now;
            timer1.Enabled = true;
            if (SendID.Substring(0, 1) != "A")
            {
                info.Enabled = false;
                if (SendID.Substring(0, 1) != "B")
                {
                    sale.Enabled = false;

                }
                if (SendID.Substring(0, 1) != "C")
                {
                    product.Enabled = false;
                    custom.Enabled = false;
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "系统当前时间:"+DateTime.Now;
        }

        private void 员工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee(SendID);
            employee.Show();
            this.Hide();
        }

        private void 供应商ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier(SendID);
            supplier.Show();
            this.Hide();
        }

        private void 商品信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_info product_info = new Product_info(SendID);
            product_info.Show();
            this.Hide();
        }
        private void 商品查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_manage product_search = new Product_manage(SendID);
            product_search.Show();
            this.Hide();
        }

        private void 商品销售ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale sale = new Sale(SendID);
            sale.Show();
            this.Hide();
        }

        private void 商品退货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refund refund = new Refund(SendID);
            refund.Show();
            this.Hide();
        }

        //private void 库存报警ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Inventory_warn inventory_warn = new Inventory_warn(SendID);
        //    inventory_warn.Show();
        //    this.Hide();
        //}

        //private void 库存查询ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    Inventory_search inventory_search = new Inventory_search(SendID);
        //    inventory_search.Show();
        //    this.Hide();
        //}

        private void 会员管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Custom custom = new Custom(SendID);
            custom.Show();
            this.Hide();
        }

        private void 销售信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sale_Info sale_Info = new Sale_Info(SendID);
            sale_Info.Show();
            this.Hide();
        }
    }
}
