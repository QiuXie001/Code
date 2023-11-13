
namespace 超市进销存管理系统
{
    partial class Inventory_search
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.save = new System.Windows.Forms.ToolStripButton();
            this.cancel = new System.Windows.Forms.ToolStripButton();
            this.add = new System.Windows.Forms.ToolStripButton();
            this.update = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.查询条件 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.search = new System.Windows.Forms.ToolStripButton();
            this.exit = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.cancel,
            this.add,
            this.update,
            this.delete,
            this.toolStripSeparator1,
            this.查询条件,
            this.toolStripComboBox1,
            this.toolStripTextBox1,
            this.search,
            this.exit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(920, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // save
            // 
            this.save.Image = global::超市进销存管理系统.Properties.Resources.save;
            this.save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(63, 28);
            this.save.Text = "保存";
            // 
            // cancel
            // 
            this.cancel.Image = global::超市进销存管理系统.Properties.Resources.cancle;
            this.cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(63, 28);
            this.cancel.Text = "取消";
            // 
            // add
            // 
            this.add.Image = global::超市进销存管理系统.Properties.Resources.add;
            this.add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(63, 28);
            this.add.Text = "添加";
            // 
            // update
            // 
            this.update.Image = global::超市进销存管理系统.Properties.Resources.update;
            this.update.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(63, 28);
            this.update.Text = "修改";
            // 
            // delete
            // 
            this.delete.Image = global::超市进销存管理系统.Properties.Resources.delete;
            this.delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(63, 28);
            this.delete.Text = "删除";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // 查询条件
            // 
            this.查询条件.Name = "查询条件";
            this.查询条件.Size = new System.Drawing.Size(84, 28);
            this.查询条件.Text = "查询条件：";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(120, 31);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(132, 31);
            // 
            // search
            // 
            this.search.Image = global::超市进销存管理系统.Properties.Resources.select;
            this.search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(63, 28);
            this.search.Text = "查询";
            // 
            // exit
            // 
            this.exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exit.Image = global::超市进销存管理系统.Properties.Resources.exit;
            this.exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(63, 28);
            this.exit.Text = "退出";
            this.exit.Click += new System.EventHandler(this.exit_Click);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 623);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(920, 26);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(13, 20);
            this.toolStripStatusLabel4.Text = "|";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(0, 20);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Inventory_search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 649);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Inventory_search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "库存查询";
            this.Load += new System.EventHandler(this.Inventory_search_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton save;
        private System.Windows.Forms.ToolStripButton cancel;
        private System.Windows.Forms.ToolStripButton add;
        private System.Windows.Forms.ToolStripButton update;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel 查询条件;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton search;
        private System.Windows.Forms.ToolStripButton exit;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.Timer timer1;
    }
}