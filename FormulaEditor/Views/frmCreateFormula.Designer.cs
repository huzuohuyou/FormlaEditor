namespace FormulaEditor
{
    partial class frmCreateFormula
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtb_note = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_param1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TextPanel = new System.Windows.Forms.GroupBox();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.gb_fm = new System.Windows.Forms.GroupBox();
            this.gb_fz = new System.Windows.Forms.GroupBox();
            this.btn_preview = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_test = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tv_dataItems = new System.Windows.Forms.TreeView();
            this.gb_param = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gb_param1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.TextPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(561, 502);
            this.splitContainer1.SplitterDistance = 153;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtb_note);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.gb_param1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 153);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "方法名";
            // 
            // rtb_note
            // 
            this.rtb_note.Location = new System.Drawing.Point(58, 20);
            this.rtb_note.Name = "rtb_note";
            this.rtb_note.Size = new System.Drawing.Size(501, 53);
            this.rtb_note.TabIndex = 2;
            this.rtb_note.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "描  述:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // gb_param1
            // 
            this.gb_param1.Controls.Add(this.gb_param);
            this.gb_param1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gb_param1.Location = new System.Drawing.Point(3, 79);
            this.gb_param1.Name = "gb_param1";
            this.gb_param1.Size = new System.Drawing.Size(555, 71);
            this.gb_param1.TabIndex = 11;
            this.gb_param1.TabStop = false;
            this.gb_param1.Text = "参数";
            this.gb_param1.DragDrop += new System.Windows.Forms.DragEventHandler(this.gb_param_DragDrop);
            this.gb_param1.DragEnter += new System.Windows.Forms.DragEventHandler(this.gb_param_DragEnter);
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
            this.splitContainer2.Panel1.Controls.Add(this.TextPanel);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btn_preview);
            this.splitContainer2.Panel2.Controls.Add(this.btn_save);
            this.splitContainer2.Panel2.Controls.Add(this.btn_test);
            this.splitContainer2.Size = new System.Drawing.Size(561, 348);
            this.splitContainer2.SplitterDistance = 322;
            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // TextPanel
            // 
            this.TextPanel.Controls.Add(this.splitContainer4);
            this.TextPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextPanel.Location = new System.Drawing.Point(0, 0);
            this.TextPanel.Name = "TextPanel";
            this.TextPanel.Size = new System.Drawing.Size(561, 322);
            this.TextPanel.TabIndex = 0;
            this.TextPanel.TabStop = false;
            this.TextPanel.Text = "方法体";
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 17);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.gb_fm);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.gb_fz);
            this.splitContainer4.Size = new System.Drawing.Size(555, 302);
            this.splitContainer4.SplitterDistance = 153;
            this.splitContainer4.TabIndex = 0;
            // 
            // gb_fm
            // 
            this.gb_fm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_fm.Location = new System.Drawing.Point(0, 0);
            this.gb_fm.Name = "gb_fm";
            this.gb_fm.Size = new System.Drawing.Size(555, 153);
            this.gb_fm.TabIndex = 0;
            this.gb_fm.TabStop = false;
            this.gb_fm.Text = "分母公式";
            // 
            // gb_fz
            // 
            this.gb_fz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_fz.Location = new System.Drawing.Point(0, 0);
            this.gb_fz.Name = "gb_fz";
            this.gb_fz.Size = new System.Drawing.Size(555, 145);
            this.gb_fz.TabIndex = 1;
            this.gb_fz.TabStop = false;
            this.gb_fz.Text = "分子公式";
            // 
            // btn_preview
            // 
            this.btn_preview.Location = new System.Drawing.Point(312, -1);
            this.btn_preview.Name = "btn_preview";
            this.btn_preview.Size = new System.Drawing.Size(75, 23);
            this.btn_preview.TabIndex = 11;
            this.btn_preview.Text = "预览";
            this.btn_preview.UseVisualStyleBackColor = true;
            this.btn_preview.Click += new System.EventHandler(this.btn_preview_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(393, -1);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "保存";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(119, 2);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(75, 23);
            this.btn_test.TabIndex = 12;
            this.btn_test.Text = "测试";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Visible = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer3.Size = new System.Drawing.Size(771, 502);
            this.splitContainer3.SplitterDistance = 206;
            this.splitContainer3.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tv_dataItems);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(206, 502);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "数据项";
            // 
            // tv_dataItems
            // 
            this.tv_dataItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_dataItems.ItemHeight = 24;
            this.tv_dataItems.Location = new System.Drawing.Point(3, 17);
            this.tv_dataItems.Name = "tv_dataItems";
            this.tv_dataItems.Size = new System.Drawing.Size(200, 482);
            this.tv_dataItems.TabIndex = 0;
            this.tv_dataItems.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tv_dataItems_ItemDrag);
            this.tv_dataItems.DragEnter += new System.Windows.Forms.DragEventHandler(this.tv_dataItems_DragEnter);
            this.tv_dataItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_dataItems_MouseDown);
            // 
            // gb_param
            // 
            this.gb_param.AutoScroll = true;
            this.gb_param.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_param.Location = new System.Drawing.Point(3, 17);
            this.gb_param.Name = "gb_param";
            this.gb_param.Size = new System.Drawing.Size(549, 51);
            this.gb_param.TabIndex = 0;
            this.gb_param.DragDrop += new System.Windows.Forms.DragEventHandler(this.gb_param_DragDrop);
            this.gb_param.DragEnter += new System.Windows.Forms.DragEventHandler(this.gb_param_DragEnter);
            // 
            // frmCreateFormula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 502);
            this.Controls.Add(this.splitContainer3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateFormula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "创建指标算法";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_param1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.TextPanel.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox TextPanel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btn_preview;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.GroupBox gb_fm;
        private System.Windows.Forms.GroupBox gb_fz;
        private System.Windows.Forms.GroupBox gb_param1;
        private System.Windows.Forms.RichTextBox rtb_note;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView tv_dataItems;
        private System.Windows.Forms.Panel gb_param;
    }
}