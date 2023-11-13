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
    public partial class Inventory_warn : Form
    {
        public Inventory_warn()
        {
            InitializeComponent();
        }
        string SendID;
        public Inventory_warn(string user)
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

        private void Inventory_warn_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "当前操作员：" + SendID;
            toolStripStatusLabel5.Text = "登录时间：" + DateTime.Now;
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
            timer1.Enabled = true;
        }
    }
}
