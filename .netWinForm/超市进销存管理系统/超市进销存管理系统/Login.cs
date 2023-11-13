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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox2.PasswordChar = '\0';
            else
                textBox2.PasswordChar = '*';
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("用户名或密码不能为空！");
            else
            {
                int n = DBHelper.Emp_Exist(textBox1.Text.Trim(), textBox2.Text.Trim());
                if (n == 0)
                    MessageBox.Show("登录失败！");
                else
                {
                    MessageBox.Show("登录成功！");
                    Homepage homepage = new Homepage(textBox1.Text);
                    homepage.Show();
                    this.Hide();
                }
                    
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


    }
}
