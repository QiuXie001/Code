namespace 超市进销存管理系统
{
    partial class Employee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cancel = new System.Windows.Forms.ToolStripButton();
            this.add = new System.Windows.Forms.ToolStripButton();
            this.update = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.查询条件 = new System.Windows.Forms.ToolStripLabel();
            this.SearchCombobox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.search = new System.Windows.Forms.ToolStripButton();
            this.exit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Guyong = new System.Windows.Forms.DateTimePicker();
            this.Postcode = new System.Windows.Forms.TextBox();
            this.Salary = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Birth = new System.Windows.Forms.DateTimePicker();
            this.Department = new System.Windows.Forms.ComboBox();
            this.Title = new System.Windows.Forms.ComboBox();
            this.Sex = new System.Windows.Forms.ComboBox();
            this.ID = new System.Windows.Forms.TextBox();
            this.Pwd = new System.Windows.Forms.TextBox();
            this.Note = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.TextBox();
            this.Telephone = new System.Windows.Forms.TextBox();
            this.Identity = new System.Windows.Forms.TextBox();
            this.EmpName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancel,
            this.add,
            this.update,
            this.delete,
            this.toolStripSeparator1,
            this.查询条件,
            this.SearchCombobox,
            this.toolStripTextBox1,
            this.search,
            this.exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(690, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cancel
            // 
            this.cancel.Image = global::超市进销存管理系统.Properties.Resources.cancle;
            this.cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(56, 24);
            this.cancel.Text = "取消";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // add
            // 
            this.add.Image = global::超市进销存管理系统.Properties.Resources.add;
            this.add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(56, 24);
            this.add.Text = "添加";
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // update
            // 
            this.update.Image = global::超市进销存管理系统.Properties.Resources.update;
            this.update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(56, 24);
            this.update.Text = "修改";
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // delete
            // 
            this.delete.Image = global::超市进销存管理系统.Properties.Resources.delete;
            this.delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(56, 24);
            this.delete.Text = "删除";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // 查询条件
            // 
            this.查询条件.Name = "查询条件";
            this.查询条件.Size = new System.Drawing.Size(68, 24);
            this.查询条件.Text = "查询条件：";
            // 
            // SearchCombobox
            // 
            this.SearchCombobox.Name = "SearchCombobox";
            this.SearchCombobox.Size = new System.Drawing.Size(91, 27);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            // 
            // search
            // 
            this.search.Image = global::超市进销存管理系统.Properties.Resources.select;
            this.search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(56, 24);
            this.search.Text = "查询";
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // exit
            // 
            this.exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exit.Image = global::超市进销存管理系统.Properties.Resources.exit;
            this.exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(56, 24);
            this.exit.Text = "退出";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Guyong);
            this.groupBox1.Controls.Add(this.Postcode);
            this.groupBox1.Controls.Add(this.Salary);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.Birth);
            this.groupBox1.Controls.Add(this.Department);
            this.groupBox1.Controls.Add(this.Title);
            this.groupBox1.Controls.Add(this.Sex);
            this.groupBox1.Controls.Add(this.ID);
            this.groupBox1.Controls.Add(this.Pwd);
            this.groupBox1.Controls.Add(this.Note);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Address);
            this.groupBox1.Controls.Add(this.Telephone);
            this.groupBox1.Controls.Add(this.Identity);
            this.groupBox1.Controls.Add(this.EmpName);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 263);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "员工信息";
            // 
            // Guyong
            // 
            this.Guyong.CustomFormat = "yyyy-MM-dd";
            this.Guyong.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Guyong.Location = new System.Drawing.Point(421, 98);
            this.Guyong.Name = "Guyong";
            this.Guyong.Size = new System.Drawing.Size(108, 21);
            this.Guyong.TabIndex = 28;
            // 
            // Postcode
            // 
            this.Postcode.Location = new System.Drawing.Point(422, 66);
            this.Postcode.Name = "Postcode";
            this.Postcode.Size = new System.Drawing.Size(109, 21);
            this.Postcode.TabIndex = 27;
            // 
            // Salary
            // 
            this.Salary.Location = new System.Drawing.Point(422, 30);
            this.Salary.Name = "Salary";
            this.Salary.Size = new System.Drawing.Size(109, 21);
            this.Salary.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(364, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "邮    编";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(364, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 24;
            this.label13.Text = "工    资";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(364, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 23;
            this.label14.Text = "入职时间";
            // 
            // Birth
            // 
            this.Birth.CustomFormat = "yyyy-MM-dd";
            this.Birth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Birth.Location = new System.Drawing.Point(235, 98);
            this.Birth.Name = "Birth";
            this.Birth.Size = new System.Drawing.Size(108, 21);
            this.Birth.TabIndex = 22;
            // 
            // Department
            // 
            this.Department.FormattingEnabled = true;
            this.Department.Location = new System.Drawing.Point(580, 102);
            this.Department.Name = "Department";
            this.Department.Size = new System.Drawing.Size(67, 20);
            this.Department.TabIndex = 21;
            // 
            // Title
            // 
            this.Title.FormattingEnabled = true;
            this.Title.Location = new System.Drawing.Point(580, 65);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(67, 20);
            this.Title.TabIndex = 20;
            // 
            // Sex
            // 
            this.Sex.FormattingEnabled = true;
            this.Sex.Location = new System.Drawing.Point(580, 30);
            this.Sex.Name = "Sex";
            this.Sex.Size = new System.Drawing.Size(67, 20);
            this.Sex.TabIndex = 19;
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(234, 30);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(109, 21);
            this.ID.TabIndex = 17;
            // 
            // Pwd
            // 
            this.Pwd.Location = new System.Drawing.Point(234, 65);
            this.Pwd.Name = "Pwd";
            this.Pwd.Size = new System.Drawing.Size(109, 21);
            this.Pwd.TabIndex = 16;
            // 
            // Note
            // 
            this.Note.Location = new System.Drawing.Point(70, 196);
            this.Note.Multiline = true;
            this.Note.Name = "Note";
            this.Note.Size = new System.Drawing.Size(576, 57);
            this.Note.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "工    号";
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(70, 140);
            this.Address.Multiline = true;
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(576, 50);
            this.Address.TabIndex = 10;
            // 
            // Telephone
            // 
            this.Telephone.Location = new System.Drawing.Point(70, 102);
            this.Telephone.Name = "Telephone";
            this.Telephone.Size = new System.Drawing.Size(100, 21);
            this.Telephone.TabIndex = 13;
            // 
            // Identity
            // 
            this.Identity.Location = new System.Drawing.Point(70, 65);
            this.Identity.Name = "Identity";
            this.Identity.Size = new System.Drawing.Size(100, 21);
            this.Identity.TabIndex = 12;
            // 
            // EmpName
            // 
            this.EmpName.Location = new System.Drawing.Point(70, 27);
            this.EmpName.Name = "EmpName";
            this.EmpName.Size = new System.Drawing.Size(100, 21);
            this.EmpName.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(545, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "头衔";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(545, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "性别";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(545, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "部门";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(178, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "出生日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(176, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "系统密码";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "备    注";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "地    址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "电    话";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "身份证号";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓    名";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 327);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(666, 160);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 26);
            // 
            // SelectToolStripMenuItem
            // 
            this.SelectToolStripMenuItem.Name = "SelectToolStripMenuItem";
            this.SelectToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.SelectToolStripMenuItem.Text = "Select";
            this.SelectToolStripMenuItem.Click += new System.EventHandler(this.SelectToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel5});
            this.statusStrip1.Location = new System.Drawing.Point(0, 497);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(690, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 519);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "员工基本信息";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel 查询条件;
        private System.Windows.Forms.ToolStripComboBox SearchCombobox;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton cancel;
        private System.Windows.Forms.ToolStripButton add;
        private System.Windows.Forms.ToolStripButton update;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripButton search;
        private System.Windows.Forms.ToolStripButton exit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker Birth;
        private System.Windows.Forms.ComboBox Department;
        private System.Windows.Forms.ComboBox Title;
        private System.Windows.Forms.ComboBox Sex;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.TextBox Pwd;
        private System.Windows.Forms.TextBox Note;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.TextBox Telephone;
        private System.Windows.Forms.TextBox Identity;
        private System.Windows.Forms.TextBox EmpName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SelectToolStripMenuItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Postcode;
        private System.Windows.Forms.TextBox Salary;
        private System.Windows.Forms.DateTimePicker Guyong;
    }
}