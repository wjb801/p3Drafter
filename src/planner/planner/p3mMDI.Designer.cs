
namespace planner
{
    partial class p3mMDI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MENU_FILE = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_FILE_OPEN = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_FILE_QUIT = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_HELP = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_HELP_ABOUT = new System.Windows.Forms.ToolStripMenuItem();
            this.MENU_HELP_USAGE = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip_project = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.项目添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.项目编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.项目删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.p3mWidget_GanttChart1 = new p3mWidget.p3mWidget_GanttChart();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuStrip_project.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MENU_FILE,
            this.MENU_HELP});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(959, 25);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MENU_FILE
            // 
            this.MENU_FILE.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MENU_FILE_OPEN,
            this.MENU_FILE_QUIT});
            this.MENU_FILE.Name = "MENU_FILE";
            this.MENU_FILE.Size = new System.Drawing.Size(44, 21);
            this.MENU_FILE.Text = "文件";
            // 
            // MENU_FILE_OPEN
            // 
            this.MENU_FILE_OPEN.Name = "MENU_FILE_OPEN";
            this.MENU_FILE_OPEN.Size = new System.Drawing.Size(100, 22);
            this.MENU_FILE_OPEN.Text = "打开";
            // 
            // MENU_FILE_QUIT
            // 
            this.MENU_FILE_QUIT.Name = "MENU_FILE_QUIT";
            this.MENU_FILE_QUIT.Size = new System.Drawing.Size(100, 22);
            this.MENU_FILE_QUIT.Text = "退出";
            this.MENU_FILE_QUIT.Click += new System.EventHandler(this.MENU_FILE_QUIT_Click);
            // 
            // MENU_HELP
            // 
            this.MENU_HELP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MENU_HELP_ABOUT,
            this.MENU_HELP_USAGE});
            this.MENU_HELP.Name = "MENU_HELP";
            this.MENU_HELP.Size = new System.Drawing.Size(44, 21);
            this.MENU_HELP.Text = "帮助";
            // 
            // MENU_HELP_ABOUT
            // 
            this.MENU_HELP_ABOUT.Name = "MENU_HELP_ABOUT";
            this.MENU_HELP_ABOUT.Size = new System.Drawing.Size(124, 22);
            this.MENU_HELP_ABOUT.Text = "关于";
            // 
            // MENU_HELP_USAGE
            // 
            this.MENU_HELP_USAGE.Name = "MENU_HELP_USAGE";
            this.MENU_HELP_USAGE.Size = new System.Drawing.Size(124, 22);
            this.MENU_HELP_USAGE.Text = "使用手册";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(959, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(959, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.Controls.Add(this.p3mWidget_GanttChart1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 50);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(959, 523);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // contextMenuStrip_project
            // 
            this.contextMenuStrip_project.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.项目添加ToolStripMenuItem,
            this.项目编辑ToolStripMenuItem,
            this.toolStripSeparator1,
            this.项目删除ToolStripMenuItem});
            this.contextMenuStrip_project.Name = "contextMenuStrip_project";
            this.contextMenuStrip_project.Size = new System.Drawing.Size(129, 76);
            // 
            // 项目添加ToolStripMenuItem
            // 
            this.项目添加ToolStripMenuItem.Name = "项目添加ToolStripMenuItem";
            this.项目添加ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.项目添加ToolStripMenuItem.Text = "项目 添加";
            this.项目添加ToolStripMenuItem.Click += new System.EventHandler(this.项目添加ToolStripMenuItem_Click);
            // 
            // 项目编辑ToolStripMenuItem
            // 
            this.项目编辑ToolStripMenuItem.Name = "项目编辑ToolStripMenuItem";
            this.项目编辑ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.项目编辑ToolStripMenuItem.Text = "项目 编辑";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // 项目删除ToolStripMenuItem
            // 
            this.项目删除ToolStripMenuItem.Name = "项目删除ToolStripMenuItem";
            this.项目删除ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.项目删除ToolStripMenuItem.Text = "项目 删除";
            // 
            // p3mWidget_GanttChart1
            // 
            this.p3mWidget_GanttChart1.AutoScroll = true;
            this.p3mWidget_GanttChart1.BackColor = System.Drawing.Color.White;
            this.p3mWidget_GanttChart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.p3mWidget_GanttChart1.Location = new System.Drawing.Point(123, 0);
            this.p3mWidget_GanttChart1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.p3mWidget_GanttChart1.Name = "p3mWidget_GanttChart1";
            this.p3mWidget_GanttChart1.Size = new System.Drawing.Size(713, 523);
            this.p3mWidget_GanttChart1.TabIndex = 0;
            // 
            // p3mMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 595);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "p3mMDI";
            this.Text = "p3mMDI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.p3mMDI_FormClosing);
            this.Load += new System.EventHandler(this.p3mMDI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.contextMenuStrip_project.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MENU_FILE_QUIT;
        private System.Windows.Forms.ToolStripMenuItem MENU_HELP_ABOUT;
        private System.Windows.Forms.ToolStripMenuItem MENU_HELP_USAGE;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_project;
        private System.Windows.Forms.ToolStripMenuItem 项目添加ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 项目编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 项目删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MENU_FILE_OPEN;
        private System.Windows.Forms.ToolStripMenuItem MENU_FILE;
        private System.Windows.Forms.ToolStripMenuItem MENU_HELP;
        private p3mWidget.p3mWidget_GanttChart p3mWidget_GanttChart1;
    }
}