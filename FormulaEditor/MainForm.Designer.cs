namespace FormulaEditor
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cms_code_manager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.save = new System.Windows.Forms.ToolStripMenuItem();
            this.开始调试ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ms_singel = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.调试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始调试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tv_singal = new System.Windows.Forms.TreeView();
            this.cms_zb_manager = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.del_pyfile = new System.Windows.Forms.ToolStripMenuItem();
            this.create_pyfile = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_hide_list = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_p8 = new System.Windows.Forms.TextBox();
            this.txt_p7 = new System.Windows.Forms.TextBox();
            this.txt_p6 = new System.Windows.Forms.TextBox();
            this.txt_p5 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_func = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_p2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_p3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_p4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_p1 = new System.Windows.Forms.TextBox();
            this.TextPanel = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_hide_console = new System.Windows.Forms.Button();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.cms_console = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_code_manager.SuspendLayout();
            this.ms_singel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.cms_zb_manager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.cms_console.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms_code_manager
            // 
            this.cms_code_manager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.save,
            this.开始调试ToolStripMenuItem1});
            this.cms_code_manager.Name = "cms_code_manager";
            this.cms_code_manager.Size = new System.Drawing.Size(125, 48);
            // 
            // save
            // 
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(124, 22);
            this.save.Text = "保存";
            this.save.Click += new System.EventHandler(this.Save_Singel_Click);
            // 
            // 开始调试ToolStripMenuItem1
            // 
            this.开始调试ToolStripMenuItem1.Name = "开始调试ToolStripMenuItem1";
            this.开始调试ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.开始调试ToolStripMenuItem1.Text = "开始调试";
            this.开始调试ToolStripMenuItem1.Click += new System.EventHandler(this.debug_pyfile_Click);
            // 
            // ms_singel
            // 
            this.ms_singel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.调试ToolStripMenuItem});
            this.ms_singel.Location = new System.Drawing.Point(0, 0);
            this.ms_singel.Name = "ms_singel";
            this.ms_singel.Size = new System.Drawing.Size(998, 25);
            this.ms_singel.TabIndex = 1;
            this.ms_singel.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.新建ToolStripMenuItem1,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 新建ToolStripMenuItem1
            // 
            this.新建ToolStripMenuItem1.Name = "新建ToolStripMenuItem1";
            this.新建ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.新建ToolStripMenuItem1.Text = "新建";
            this.新建ToolStripMenuItem1.Click += new System.EventHandler(this.create_singel_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.close_frm_Click);
            // 
            // 调试ToolStripMenuItem
            // 
            this.调试ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始调试ToolStripMenuItem});
            this.调试ToolStripMenuItem.Name = "调试ToolStripMenuItem";
            this.调试ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.调试ToolStripMenuItem.Text = "调试";
            // 
            // 开始调试ToolStripMenuItem
            // 
            this.开始调试ToolStripMenuItem.Name = "开始调试ToolStripMenuItem";
            this.开始调试ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.开始调试ToolStripMenuItem.Text = "开始调试";
            this.开始调试ToolStripMenuItem.Click += new System.EventHandler(this.debug_pyfile_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(998, 416);
            this.splitContainer1.SplitterDistance = 206;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tv_singal);
            this.groupBox4.Controls.Add(this.btn_hide_list);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(206, 416);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "病种列表";
            // 
            // tv_singal
            // 
            this.tv_singal.ContextMenuStrip = this.cms_zb_manager;
            this.tv_singal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_singal.FullRowSelect = true;
            this.tv_singal.HideSelection = false;
            this.tv_singal.Indent = 12;
            this.tv_singal.ItemHeight = 24;
            this.tv_singal.Location = new System.Drawing.Point(3, 17);
            this.tv_singal.Name = "tv_singal";
            this.tv_singal.Size = new System.Drawing.Size(200, 396);
            this.tv_singal.TabIndex = 2;
            this.tv_singal.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_singal_AfterSelect);
            // 
            // cms_zb_manager
            // 
            this.cms_zb_manager.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.del_pyfile,
            this.create_pyfile});
            this.cms_zb_manager.Name = "contextMenuStrip1";
            this.cms_zb_manager.Size = new System.Drawing.Size(125, 70);
            this.cms_zb_manager.Opening += new System.ComponentModel.CancelEventHandler(this.cms_zb_manager_Opening);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.新建ToolStripMenuItem.Text = "新建指标";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.create_fun_Click);
            // 
            // del_pyfile
            // 
            this.del_pyfile.Name = "del_pyfile";
            this.del_pyfile.Size = new System.Drawing.Size(124, 22);
            this.del_pyfile.Text = "删除文件";
            this.del_pyfile.Click += new System.EventHandler(this.del_pyfile_Click);
            // 
            // create_pyfile
            // 
            this.create_pyfile.Name = "create_pyfile";
            this.create_pyfile.Size = new System.Drawing.Size(124, 22);
            this.create_pyfile.Text = "新建文件";
            this.create_pyfile.Click += new System.EventHandler(this.create_singel_Click);
            // 
            // btn_hide_list
            // 
            this.btn_hide_list.BackgroundImage = global::FormulaEditor.Properties.Resources.QQ截图20170526130606;
            this.btn_hide_list.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_hide_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_hide_list.ForeColor = System.Drawing.Color.Transparent;
            this.btn_hide_list.Location = new System.Drawing.Point(188, 1);
            this.btn_hide_list.Name = "btn_hide_list";
            this.btn_hide_list.Size = new System.Drawing.Size(16, 16);
            this.btn_hide_list.TabIndex = 1;
            this.btn_hide_list.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(791, 416);
            this.splitContainer2.SplitterDistance = 314;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 1;
            this.splitContainer2.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.TextPanel);
            this.splitContainer3.Size = new System.Drawing.Size(791, 314);
            this.splitContainer3.SplitterDistance = 66;
            this.splitContainer3.TabIndex = 1;
            this.splitContainer3.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txt_p8);
            this.groupBox3.Controls.Add(this.txt_p7);
            this.groupBox3.Controls.Add(this.txt_p6);
            this.groupBox3.Controls.Add(this.txt_p5);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txt_func);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txt_p2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txt_p3);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txt_p4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txt_p1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(791, 66);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测试";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "func";
            // 
            // txt_p8
            // 
            this.txt_p8.Location = new System.Drawing.Point(601, 40);
            this.txt_p8.Name = "txt_p8";
            this.txt_p8.Size = new System.Drawing.Size(100, 21);
            this.txt_p8.TabIndex = 1;
            this.txt_p8.Text = "8";
            // 
            // txt_p7
            // 
            this.txt_p7.Location = new System.Drawing.Point(464, 42);
            this.txt_p7.Name = "txt_p7";
            this.txt_p7.Size = new System.Drawing.Size(100, 21);
            this.txt_p7.TabIndex = 1;
            this.txt_p7.Text = "7";
            // 
            // txt_p6
            // 
            this.txt_p6.Location = new System.Drawing.Point(327, 40);
            this.txt_p6.Name = "txt_p6";
            this.txt_p6.Size = new System.Drawing.Size(100, 21);
            this.txt_p6.TabIndex = 1;
            this.txt_p6.Text = "6";
            // 
            // txt_p5
            // 
            this.txt_p5.Location = new System.Drawing.Point(190, 39);
            this.txt_p5.Name = "txt_p5";
            this.txt_p5.Size = new System.Drawing.Size(100, 21);
            this.txt_p5.TabIndex = 1;
            this.txt_p5.Text = "5";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(582, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "p8";
            // 
            // txt_func
            // 
            this.txt_func.Location = new System.Drawing.Point(37, 12);
            this.txt_func.Name = "txt_func";
            this.txt_func.Size = new System.Drawing.Size(100, 21);
            this.txt_func.TabIndex = 1;
            this.txt_func.Text = "demo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(445, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "p7";
            // 
            // txt_p2
            // 
            this.txt_p2.Location = new System.Drawing.Point(327, 12);
            this.txt_p2.Name = "txt_p2";
            this.txt_p2.Size = new System.Drawing.Size(100, 21);
            this.txt_p2.TabIndex = 1;
            this.txt_p2.Text = "2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "p6";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "p3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(171, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "p5";
            // 
            // txt_p3
            // 
            this.txt_p3.Location = new System.Drawing.Point(464, 13);
            this.txt_p3.Name = "txt_p3";
            this.txt_p3.Size = new System.Drawing.Size(100, 21);
            this.txt_p3.TabIndex = 1;
            this.txt_p3.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "p2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "p1";
            // 
            // txt_p4
            // 
            this.txt_p4.Location = new System.Drawing.Point(601, 13);
            this.txt_p4.Name = "txt_p4";
            this.txt_p4.Size = new System.Drawing.Size(100, 21);
            this.txt_p4.TabIndex = 1;
            this.txt_p4.Text = "4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(582, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "p4";
            // 
            // txt_p1
            // 
            this.txt_p1.Location = new System.Drawing.Point(190, 12);
            this.txt_p1.Name = "txt_p1";
            this.txt_p1.Size = new System.Drawing.Size(100, 21);
            this.txt_p1.TabIndex = 1;
            this.txt_p1.Text = "1";
            // 
            // TextPanel
            // 
            this.TextPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextPanel.Location = new System.Drawing.Point(0, 0);
            this.TextPanel.Name = "TextPanel";
            this.TextPanel.Size = new System.Drawing.Size(791, 244);
            this.TextPanel.TabIndex = 1;
            this.TextPanel.TabStop = false;
            this.TextPanel.Text = "代码";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_hide_console);
            this.groupBox1.Controls.Add(this.rtb_log);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(791, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输出";
            // 
            // btn_hide_console
            // 
            this.btn_hide_console.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_hide_console.BackgroundImage = global::FormulaEditor.Properties.Resources.QQ截图20170526130606;
            this.btn_hide_console.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_hide_console.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_hide_console.ForeColor = System.Drawing.Color.Transparent;
            this.btn_hide_console.Location = new System.Drawing.Point(771, -35);
            this.btn_hide_console.Name = "btn_hide_console";
            this.btn_hide_console.Size = new System.Drawing.Size(16, 16);
            this.btn_hide_console.TabIndex = 2;
            this.btn_hide_console.UseVisualStyleBackColor = true;
            // 
            // rtb_log
            // 
            this.rtb_log.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtb_log.ContextMenuStrip = this.cms_console;
            this.rtb_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_log.ForeColor = System.Drawing.Color.Lime;
            this.rtb_log.Location = new System.Drawing.Point(3, 17);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(785, 81);
            this.rtb_log.TabIndex = 0;
            this.rtb_log.Text = "";
            // 
            // cms_console
            // 
            this.cms_console.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空ToolStripMenuItem});
            this.cms_console.Name = "cms_console";
            this.cms_console.Size = new System.Drawing.Size(101, 26);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.clear_console_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 441);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.ms_singel);
            this.MainMenuStrip = this.ms_singel;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "FormulaEditor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.cms_code_manager.ResumeLayout(false);
            this.ms_singel.ResumeLayout(false);
            this.ms_singel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.cms_zb_manager.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.cms_console.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip ms_singel;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 调试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开始调试ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.ContextMenuStrip cms_zb_manager;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem del_pyfile;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox txt_p5;
        private System.Windows.Forms.TextBox txt_p2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_p4;
        private System.Windows.Forms.TextBox txt_p1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_p3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_func;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox TextPanel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_hide_list;
        private System.Windows.Forms.Button btn_hide_console;
        private System.Windows.Forms.TreeView tv_singal;
        private System.Windows.Forms.ContextMenuStrip cms_code_manager;
        private System.Windows.Forms.ToolStripMenuItem save;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem create_pyfile;
        private System.Windows.Forms.ToolStripMenuItem 开始调试ToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip cms_console;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_p8;
        private System.Windows.Forms.TextBox txt_p7;
        private System.Windows.Forms.TextBox txt_p6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

