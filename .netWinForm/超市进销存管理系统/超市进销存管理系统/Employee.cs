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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        string SendID;
        public Employee(string user)
        {
            InitializeComponent();
            SendID = user;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
        }
        string sql = "select 员工号=EmployeeID,姓名=EmployeeName,职务=EmployeeTitle,工资=EmployeeSalary  from s_employee";
        string pwd;
        List<string> sqlList;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable table = new DataTable();
        public void reFresh()
        {
            table.Clear();
            sql = "select " +
                "员工号=EmployeeID," +
                "姓名=EmployeeName," +
                "职务=EmployeeTitle," +
                "工资=EmployeeSalary  " +
                "from s_employee";
            table = DBHelper.ExecuteAdapter(sql);
            dataGridView1.DataSource = table;
            sql = "select DISTINCT EmployeeSex from s_employee";
            table = DBHelper.ExecuteAdapter(sql);
            DataRow newrow = table.NewRow();
            table.Rows.Add(newrow);
            Sex.DisplayMember = "EmployeeSex";
            Sex.DataSource = table;
            Sex.Text = "=请选择=";
            //填充性别combobox
            sql = "select DISTINCT EmployeeTitle from s_employee";
            table = DBHelper.ExecuteAdapter(sql);
            newrow = table.NewRow();
            table.Rows.Add(newrow);
            Title.DisplayMember = "EmployeeTitle";
            Title.DataSource = table;
            Title.Text = "=请选择=";
            //填充头衔combobox
            sql = "select DISTINCT DepName from s_Department";
            table = DBHelper.ExecuteAdapter(sql);
            newrow = table.NewRow();
            table.Rows.Add(newrow);
            Department.DisplayMember = "DepName";
            Department.DataSource = table;
            Department.Text = "=请选择=";
            //填充部门combobox
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
            toolStripStatusLabel3.Text = "当前操作员：" + SendID;
            toolStripStatusLabel5.Text = "登录时间：" + DateTime.Now;
            toolStripStatusLabel1.Text = "系统当前时间:" + DateTime.Now;
            timer1.Enabled = true;
            table = DBHelper.ExecuteAdapter(sql);
            dataGridView1.DataSource = table;
            sql = "select DISTINCT EmployeeSex from s_employee";
            table = DBHelper.ExecuteAdapter(sql);
            DataRow newrow = table.NewRow();
            table.Rows.Add(newrow);
            Sex.DisplayMember = "EmployeeSex";
            Sex.DataSource = table;
            Sex.Text = "=请选择=";
            //填充性别combobox
            sql = "select DISTINCT EmployeeTitle from s_employee";
            table = DBHelper.ExecuteAdapter(sql);
            newrow = table.NewRow();
            table.Rows.Add(newrow);
            Title.DisplayMember = "EmployeeTitle";
            Title.DataSource = table;
            Title.Text = "=请选择=";
            //填充头衔combobox
            sql = "select DISTINCT DepName from s_Department";
            table = DBHelper.ExecuteAdapter(sql);
            newrow = table.NewRow();
            table.Rows.Add(newrow);
            Department.DisplayMember = "DepName";
            Department.DataSource = table;
            Department.Text = "=请选择=";
            //填充部门combobox
            
            string[] bound = {"姓名","工号","工资(高于)", "工资(低于)","性别","头衔","部门"}; //添加字符串数据
            SearchCombobox.ComboBox.Items.AddRange(bound);               //将字符串数组添加至comboBox2.Items属性中
            SearchCombobox.ComboBox.Text = "=请选择=";
            //填充查询combobox
            
        }
        private void save_Click(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            if (ID.Text!="")
            {
                if (DBHelper.CheckIDCard18(Identity.Text)&&DBHelper.IsHandset(Telephone.Text))
                {
                    string DepID = "null";
                    string manager = "null";
                    string id = ID.Text;
                    sqlList = new List<string>(0);
                    SqlConnection conn, Conn;
                    string sql = "select " +//获取depid
                        "DepID " +
                        "from s_Department " +
                        "where DepName = '" + Department.Text + "'";
                    SqlDataReader read1 = DBHelper.Obtain(sql, out conn);
                    while (read1.Read())
                    {
                        DepID = read1["DepID"].ToString(); ;

                    }

                    if (id != null)//根据部门首字母获取对应主管
                    {
                        sql = "select " +
                        "EmployeeName " +
                        "from s_employee " +
                        "where EmployeeID = '" + "A00001" + "'";
                        SqlDataReader read = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                        sql = "select " +
                        "EmployeeName " +
                        "from s_employee " +
                        "where EmployeeID='" + "A00002" + "'";
                        SqlDataReader Read = DBHelper.Obtain(sql, out Conn);
                        if (id.Substring(0, 1) == "B" || id.Substring(0, 1) == "C")
                        {

                            if (id.Substring(0, 1) == "B")
                            {
                                while (read.Read())
                                {
                                    manager = read["EmployeeName"].ToString();

                                }
                            }
                            else if (id.Substring(0, 1) == "C")
                            {
                                while (Read.Read())
                                {
                                    manager = Read["EmployeeName"].ToString();
                                }
                            }
                        }
                    }
                    int n = 0;
                    if (DBHelper.User_ID_Exist(ID.Text) == 1)
                    {
                        MessageBox.Show("用户名已存在");
                    }
                    else
                    {
                        sqlList = new List<string>(0);
                        sql = ("insert into s_employee" +
                            " values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},'{9}','{10}','{11}','{12}',{13},'{14}')");
                        sql = string.Format(sql,
                            ID.Text,
                            EmpName.Text,
                            Sex.Text,
                            Identity.Text,
                            Birth.Text,
                            Guyong.Text,
                            Title.Text,
                            DepID,
                            Salary.Text,
                            Address.Text,
                            Postcode.Text,
                            Telephone.Text,
                            manager,
                            1,
                            Note.Text);
                        sqlList.Add(sql);
                        sql = ("insert into s_user " +
                            "values('{0}','{1}','{2}',{3})");
                        sql = string.Format(sql,
                            ID.Text,
                            EmpName.Text,
                            Pwd.Text,
                            DepID);
                        sqlList.Add(sql);
                        n = 1;
                        DBHelper.ExecuteNonQueryTransaction(sqlList);
                    }
                    if (n > 0)
                    {
                        MessageBox.Show("插入成功");

                        reFresh();
                    }
                }
                else MessageBox.Show("格式错误，请检查后重试");
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Homepage homepage = new Homepage(SendID);
            homepage.Show();
            this.Hide();
        }

        private void SelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = 0;
            if (this.dataGridView1.SelectedCells.Count > 0 && this.dataGridView1.SelectedCells[0].Value != null)
            {
                string DepID = "null";
                string id = this.dataGridView1.SelectedCells[0].Value.ToString();
                string sql1 = "select " +
                    "EmployeeID," +
                    "EmployeeName," +
                    "EmployeeIdentity," +
                    "EmployeeSex," +
                    "EmployeeBirth," +
                    "EmployeeGuyong," +
                    "EmployeeTitle," +
                    "EmployeeDep," +
                    "EmployeeSalary," +
                    "EmployeeAddress," +
                    "EmployeePostCode," +
                    "EmployeePhone," +
                    "EmployeeManager," +
                    "EmployeeStop," +
                    "EmployeeNote " +
                    "from s_employee " +
                    "where EmployeeID='" + id + "'";
                string sql2 = "select UserPWD " +
                    "from s_user " +
                    "where UserID ='" + id + "'";
                SqlConnection conn, Conn;
                SqlDataReader read1 = DBHelper.Obtain(sql1, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                SqlDataReader read2 = DBHelper.Obtain(sql2, out Conn);

                while (read1.Read())
                {
                    DepID = read1["EmployeeDep"].ToString();
                    EmpName.Text = read1["EmployeeName"].ToString(); //如上
                    Birth.Value = Convert.ToDateTime(read1["EmployeeBirth"]);
                    Sex.Text = read1["EmployeeSex"].ToString();
                    Identity.Text = read1["EmployeeIdentity"].ToString();
                    if (id.Substring(0, 1) != "D")
                    {
                        while (read2.Read())
                        {
                            Pwd.Text = read2["UserPWD"].ToString();
                            pwd = Pwd.Text;
                        }
                    }
                    Title.Text = read1["EmployeeTitle"].ToString();
                    Telephone.Text = read1["EmployeePhone"].ToString();
                    ID.Text = read1["EmployeeID"].ToString();
                    Address.Text = read1["EmployeeAddress"].ToString();
                    Note.Text = read1["EmployeeNote"].ToString();
                    Salary.Text = read1["EmployeeSalary"].ToString();
                    Postcode.Text = read1["EmployeePostCode"].ToString();
                    Guyong.Text = read1["EmployeeGuyong"].ToString(); ;
                }
                string sql3 = "select DepName " +//获取depid
                    "from s_Department " +
                    "where DepID ='" + DepID + "'";
                SqlDataReader read3 = DBHelper.Obtain(sql3, out Conn);
                while (read3.Read())
                {
                    Department.Text = read3["DepName"].ToString();//插入对应depname
                }
                if (conn != null) //判断con不为空
                {
                    conn.Close();
                    Conn.Close();
                }
                n = 1;
            }
            if (n > 0)
                MessageBox.Show("选中成功");
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int n = 0;
            if (this.dataGridView1.SelectedCells.Count > 0 && this.dataGridView1.SelectedCells[0].Value != null)
            {
                string DepID = "null";
                string id = this.dataGridView1.SelectedCells[0].Value.ToString();
                string sql1 = "select " +
                    "EmployeeID," +
                    "EmployeeName," +
                    "EmployeeIdentity," +
                    "EmployeeSex," +
                    "EmployeeBirth," +
                    "EmployeeGuyong," +
                    "EmployeeTitle," +
                    "EmployeeDep," +
                    "EmployeeSalary," +
                    "EmployeeAddress," +
                    "EmployeePostCode," +
                    "EmployeePhone," +
                    "EmployeeManager," +
                    "EmployeeStop," +
                    "EmployeeNote " +
                    "from s_employee " +
                    "where EmployeeID='" + id + "'";
                string sql2 = "select UserPWD " +
                    "from s_user " +
                    "where UserID ='" + id + "'";
                SqlConnection conn, Conn;
                SqlDataReader read1 = DBHelper.Obtain(sql1, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                SqlDataReader read2 = DBHelper.Obtain(sql2, out Conn);

                while (read1.Read())
                {
                    DepID = read1["EmployeeDep"].ToString();
                    EmpName.Text = read1["EmployeeName"].ToString(); //如上
                    Birth.Value = Convert.ToDateTime(read1["EmployeeBirth"]);
                    Sex.Text = read1["EmployeeSex"].ToString();
                    Identity.Text = read1["EmployeeIdentity"].ToString();
                    if (id.Substring(0, 1) != "D")
                    {
                        while (read2.Read())
                        {
                            Pwd.Text = read2["UserPWD"].ToString();
                            pwd = Pwd.Text;
                        }
                    }
                    Title.Text = read1["EmployeeTitle"].ToString();
                    Telephone.Text = read1["EmployeePhone"].ToString();
                    ID.Text = read1["EmployeeID"].ToString();
                    Address.Text = read1["EmployeeAddress"].ToString();
                    Note.Text = read1["EmployeeNote"].ToString();
                    Salary.Text = read1["EmployeeSalary"].ToString();
                    Postcode.Text = read1["EmployeePostCode"].ToString();
                    Guyong.Text = read1["EmployeeGuyong"].ToString(); ;
                }
                string sql3 = "select DepName " +//获取depid
                    "from s_Department " +
                    "where DepID ='" + DepID + "'";
                SqlDataReader read3 = DBHelper.Obtain(sql3, out Conn);
                while (read3.Read())
                {
                    Department.Text = read3["DepName"].ToString();//插入对应depname
                }
                if (conn != null) //判断con不为空
                {
                    conn.Close();
                    Conn.Close();
                }
                n = 1;
            }
            if (n > 0)
                MessageBox.Show("选中成功");
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (ID.Text != "")
            {
                int n = 0;
                string id = ID.Text;
                sqlList = new List<string>(0);
                int i = 0;
                if (id.Substring(0, 1) != "D")
                {
                    sqlList.Add("delete from s_user where UserID ='" + id + "'");
                    n++;
                }
                else
                {
                    sqlList.Add("delete from s_employee where EmployeeID ='" + id + "'");
                    n++;
                }

                DBHelper.ExecuteNonQueryTransaction(sqlList);

                reFresh();

                if (n > 0)
                {
                    MessageBox.Show("删除成功");
                }
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (ID.Text != "") 
            {
                if (DBHelper.CheckIDCard18(Identity.Text) && DBHelper.IsHandset(Telephone.Text))
                {
                    int n = 0;
                    string manager = "null";
                    string DepID = "null";
                    string id = ID.Text;
                    sqlList = new List<string>(0);
                    SqlConnection conn, Conn;
                    string sql = "select " +//获取depid
                    "DepID " +
                    "from s_Department " +
                    "where DepName = '" + Department.Text + "'";
                    SqlDataReader Rread = DBHelper.Obtain(sql, out conn);
                    while (Rread.Read())
                    {
                        DepID = Rread["DepID"].ToString();
                    }
                    if (id != "")//根据部门首字母获取对应主管
                    {
                        sql = "select " +
                        "EmployeeName " +
                        "from s_employee " +
                        "where EmployeeID = '" + "A00001" + "'";
                        SqlDataReader read = DBHelper.Obtain(sql, out conn);//用com(变量名)点上ExecuteReader()方法,该方法的类型是SqlDataReader类型
                        sql = "select " +
                        "EmployeeName " +
                        "from s_employee " +
                        "where EmployeeID='" + "A00002" + "'";
                        SqlDataReader Read = DBHelper.Obtain(sql, out Conn);
                        if (id.Substring(0, 1) == "B" || id.Substring(0, 1) == "C")
                        {

                            if (id.Substring(0, 1) == "B")
                            {
                                while (read.Read())
                                {
                                    manager = read["EmployeeName"].ToString();

                                }
                            }
                            else if (id.Substring(0, 1) == "C")
                            {
                                while (Read.Read())
                                {
                                    manager = Read["EmployeeName"].ToString();
                                }
                            }
                        }
                        if (pwd == Pwd.Text)
                        {
                            sqlList.Add("update s_employee set " +
                                "EmployeeID = '" + id + "'," +
                                "EmployeeName = '" + EmpName.Text + "'," +
                                "EmployeeSex = '" + Sex.Text + "'," +
                                "EmployeeIdentity = '" + Identity.Text + "'," +
                                "EmployeeBirth =  '" + Birth.Text + "' ," +
                                "EmployeeGuyong = '" + Guyong.Text + "'," +
                                "EmployeeTitle = '" + Title.Text + "'," +
                                "EmployeeDep = '" + DepID + "'," +
                                "EmployeeSalary = '" + Salary.Text + "'," +
                                "EmployeeAddress = '" + Address.Text + "'," +
                                "EmployeePostCode = '" + Postcode.Text + "'," +
                                "EmployeePhone = '" + Telephone.Text + "'," +
                                "EmployeeManager = '" + manager + "'," +
                                "EmployeeStop = " + 1 + "," +
                                "EmployeeNote = '" + Note.Text + "'" +
                                "where EmployeeID ='" + id + "'");
                            n++;

                        }
                        else
                        {
                            sqlList.Add("update s_employee set " +
                                "EmployeeID = '" + id + "'," +
                                "EmployeeName = '" + EmpName.Text + "'," +
                                "EmployeeSex = '" + Sex.Text + "'," +
                                "EmployeeIdentity = '" + Identity.Text + "'," +
                                "EmployeeBirth =  '" + Birth.Text + "' ," +
                                "EmployeeGuyong = '" + Guyong.Text + "'," +
                                "EmployeeTitle = '" + Title.Text + "'," +
                                "EmployeeDep = '" + DepID + "'," +
                                "EmployeeSalary = '" + Salary.Text + "'," +
                                "EmployeeAddress = '" + Address.Text + "'," +
                                "EmployeePostCode = " + Postcode.Text + "," +
                                "EmployeePhone = '" + Telephone.Text + "'," +
                                "EmployeeManager = '" + manager + "'," +
                                "EmployeeStop = " + 1 + "," +
                                "EmployeeNote = '" + Note.Text + "'" +
                                "where EmployeeID ='" + id + "'");
                            sqlList.Add("update s_user set " +
                                "UserID ='" + id + "'," +
                                "UserName ='" + EmpName.Text + "'," +
                                "UserPWD ='" + Pwd.Text + "'," +
                                "UserDep ='" + DepID + "'" +//DepID需要从dep表中查出
                                "where UserID ='" + id + "'");

                            n++;
                        }
                    }
                    DBHelper.ExecuteNonQueryTransaction(sqlList);
                    reFresh();

                    if (n > 0)
                        MessageBox.Show("更改成功");
                }
                else MessageBox.Show("格式错误，请检查后重试");
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            if(SearchCombobox.Text == "姓名")//Name查询
            {
                sql = "select 员工号=EmployeeID," +
                    "姓名=EmployeeName," +
                    "职务=EmployeeTitle," +
                    "工资=EmployeeSalary "+
                "from s_employee " +
                "where EmployeeName like '%" + toolStripTextBox1.Text + "%'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "工号")//ID查询
            {
                sql = "select 员工号=EmployeeID," +
                    "姓名=EmployeeName," +
                    "职务=EmployeeTitle," +
                    "工资=EmployeeSalary " +
                "from s_employee " +
                "where EmployeeID like '%" + toolStripTextBox1.Text + "%'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "工资(高于)")//Salary查询
            {
                sql = "select 员工号=EmployeeID," +
                    "姓名=EmployeeName," +
                    "职务=EmployeeTitle," +
                    "工资=EmployeeSalary " +
                "from s_employee " +
                "where EmployeeSalary >= '" + toolStripTextBox1.Text + "'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "工资(低于)")//Salary查询
            {
                sql = "select 员工号=EmployeeID," +
                    "姓名=EmployeeName," +
                    "职务=EmployeeTitle," +
                    "工资=EmployeeSalary " +
                "from s_employee " +
                "where EmployeeSalary <= '" + toolStripTextBox1.Text + "'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "性别")//Sex查询
            {
                sql = "select 员工号=EmployeeID," +
                    "姓名=EmployeeName," +
                    "职务=EmployeeTitle," +
                    "工资=EmployeeSalary " +
                "from s_employee " +
                "where EmployeeSex = '" + toolStripTextBox1.Text + "'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "头衔")//Tittle查询
            {
                sql = "select 员工号=EmployeeID," +
                    "姓名=EmployeeName," +
                    "职务=EmployeeTitle," +
                    "工资=EmployeeSalary " +
                "from s_employee " +
                "where EmployeeTittle like '%" + toolStripTextBox1.Text + "%'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
            else if (SearchCombobox.Text == "部门")//Department查询
            {
                sql = "select 员工号=EmployeeID,姓名=EmployeeName,职务=EmployeeTitle,工资=EmployeeSalary " +
                    "from s_employee  inner join s_Department  " +
                    "on s_employee.EmployeeDep = s_Department.DepID " +
                    "where DepName like '%"+ toolStripTextBox1.Text + "%'";
                table = DBHelper.ExecuteAdapter(sql);
                dataGridView1.DataSource = table;
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Employee employee = new Employee(SendID);
            employee.Show();
        }

        
    }
}
