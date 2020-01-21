namespace orz {
    partial class FrmMain {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Menu1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportUsersList = new System.Windows.Forms.ToolStripMenuItem();
            this.UsersList = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.roundButton1 = new orz.roundButton();
            this.已中奖ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(555, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Menu";
            // 
            // Menu1
            // 
            this.Menu1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportUsersList,
            this.UsersList,
            this.已中奖ToolStripMenuItem});
            this.Menu1.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F);
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(51, 24);
            this.Menu1.Text = "菜单";
            // 
            // ImportUsersList
            // 
            this.ImportUsersList.Name = "ImportUsersList";
            this.ImportUsersList.Size = new System.Drawing.Size(152, 24);
            this.ImportUsersList.Text = "导入用户";
            this.ImportUsersList.Click += new System.EventHandler(this.ImportUsersList_Click);
            // 
            // UsersList
            // 
            this.UsersList.Name = "UsersList";
            this.UsersList.Size = new System.Drawing.Size(152, 24);
            this.UsersList.Text = "用户列表";
            this.UsersList.Click += new System.EventHandler(this.UsersList_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.roundButton1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.28788F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.71212F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(555, 338);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("幼圆", 54F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(509, 204);
            this.label1.TabIndex = 1;
            this.label1.Text = "风霜碎月";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.Wheat;
            this.roundButton1.Dock = System.Windows.Forms.DockStyle.Right;
            this.roundButton1.FlatAppearance.BorderSize = 0;
            this.roundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roundButton1.Font = new System.Drawing.Font("华文新魏", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.roundButton1.Location = new System.Drawing.Point(442, 227);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(90, 98);
            this.roundButton1.TabIndex = 2;
            this.roundButton1.Text = "月月的肯定";
            this.roundButton1.UseVisualStyleBackColor = false;
            this.roundButton1.Click += new System.EventHandler(this.rbtnDiceRoller_Click);
            // 
            // 已中奖ToolStripMenuItem
            // 
            this.已中奖ToolStripMenuItem.Name = "已中奖ToolStripMenuItem";
            this.已中奖ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.已中奖ToolStripMenuItem.Text = "已中奖";
            this.已中奖ToolStripMenuItem.Click += new System.EventHandler(this.已中奖ToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 366);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 10F);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "乱月";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Menu1;
        private System.Windows.Forms.ToolStripMenuItem ImportUsersList;
        private System.Windows.Forms.ToolStripMenuItem UsersList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private roundButton roundButton1;
        private System.Windows.Forms.ToolStripMenuItem 已中奖ToolStripMenuItem;
    }
}

