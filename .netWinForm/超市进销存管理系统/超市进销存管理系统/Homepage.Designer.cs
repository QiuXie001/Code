namespace 超市进销存管理系统
{
    partial class Homepage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Homepage));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.info = new System.Windows.Forms.ToolStripMenuItem();
            this.员工ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.供应商ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.product = new System.Windows.Forms.ToolStripMenuItem();
            this.商品信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sale = new System.Windows.Forms.ToolStripMenuItem();
            this.商品销售ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品退货ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.销售信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripButton();
            this.custom = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.info,
            this.product,
            this.sale,
            this.exit,
            this.custom});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(690, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // info
            // 
            this.info.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.员工ToolStripMenuItem,
            this.供应商ToolStripMenuItem});
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(68, 27);
            this.info.Text = "基本档案";
            // 
            // 员工ToolStripMenuItem
            // 
            this.员工ToolStripMenuItem.Name = "员工ToolStripMenuItem";
            this.员工ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.员工ToolStripMenuItem.Text = "员工信息";
            this.员工ToolStripMenuItem.Click += new System.EventHandler(this.员工ToolStripMenuItem_Click);
            // 
            // 供应商ToolStripMenuItem
            // 
            this.供应商ToolStripMenuItem.Name = "供应商ToolStripMenuItem";
            this.供应商ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.供应商ToolStripMenuItem.Text = "供应商信息";
            this.供应商ToolStripMenuItem.Click += new System.EventHandler(this.供应商ToolStripMenuItem_Click);
            // 
            // product
            // 
            this.product.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.商品信息ToolStripMenuItem,
            this.商品查询ToolStripMenuItem});
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(68, 27);
            this.product.Text = "商品管理";
            // 
            // 商品信息ToolStripMenuItem
            // 
            this.商品信息ToolStripMenuItem.Name = "商品信息ToolStripMenuItem";
            this.商品信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.商品信息ToolStripMenuItem.Text = "商品信息";
            this.商品信息ToolStripMenuItem.Click += new System.EventHandler(this.商品信息ToolStripMenuItem_Click);
            // 
            // 商品查询ToolStripMenuItem
            // 
            this.商品查询ToolStripMenuItem.Name = "商品查询ToolStripMenuItem";
            this.商品查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.商品查询ToolStripMenuItem.Text = "商品管理";
            this.商品查询ToolStripMenuItem.Click += new System.EventHandler(this.商品查询ToolStripMenuItem_Click);
            // 
            // sale
            // 
            this.sale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.商品销售ToolStripMenuItem,
            this.商品退货ToolStripMenuItem,
            this.销售信息ToolStripMenuItem});
            this.sale.Name = "sale";
            this.sale.Size = new System.Drawing.Size(68, 27);
            this.sale.Text = "销售管理";
            // 
            // 商品销售ToolStripMenuItem
            // 
            this.商品销售ToolStripMenuItem.Name = "商品销售ToolStripMenuItem";
            this.商品销售ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.商品销售ToolStripMenuItem.Text = "商品销售";
            this.商品销售ToolStripMenuItem.Click += new System.EventHandler(this.商品销售ToolStripMenuItem_Click);
            // 
            // 商品退货ToolStripMenuItem
            // 
            this.商品退货ToolStripMenuItem.Name = "商品退货ToolStripMenuItem";
            this.商品退货ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.商品退货ToolStripMenuItem.Text = "商品退货";
            this.商品退货ToolStripMenuItem.Click += new System.EventHandler(this.商品退货ToolStripMenuItem_Click);
            // 
            // 销售信息ToolStripMenuItem
            // 
            this.销售信息ToolStripMenuItem.Name = "销售信息ToolStripMenuItem";
            this.销售信息ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.销售信息ToolStripMenuItem.Text = "销售信息";
            this.销售信息ToolStripMenuItem.Click += new System.EventHandler(this.销售信息ToolStripMenuItem_Click);
            // 
            // exit
            // 
            this.exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.exit.Image = global::超市进销存管理系统.Properties.Resources.exit;
            this.exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(80, 24);
            this.exit.Text = "切换账号";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // custom
            // 
            this.custom.Name = "custom";
            this.custom.Size = new System.Drawing.Size(68, 27);
            this.custom.Text = "会员管理";
            this.custom.Click += new System.EventHandler(this.会员管理ToolStripMenuItem1_Click);
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
            this.statusStrip1.TabIndex = 1;
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
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 519);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Homepage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超市进销存系统";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem info;
        private System.Windows.Forms.ToolStripMenuItem 员工ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 供应商ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem product;
        private System.Windows.Forms.ToolStripMenuItem 商品信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sale;
        private System.Windows.Forms.ToolStripMenuItem 商品销售ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品退货ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton exit;
        private System.Windows.Forms.ToolStripMenuItem custom;
        private System.Windows.Forms.ToolStripMenuItem 销售信息ToolStripMenuItem;
    }
}