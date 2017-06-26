namespace FormulaEditor.Views
{
    partial class frmDemo
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
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("节点0");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19});
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("节点3");
            this.iconTabControl1 = new Common.Wfcl.IconTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cTreeView1 = new Common.Wfcl.CTreeView();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.iconTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconTabControl1
            // 
            this.iconTabControl1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.iconTabControl1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.iconTabControl1.Controls.Add(this.tabPage1);
            this.iconTabControl1.Controls.Add(this.tabPage2);
            this.iconTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconTabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iconTabControl1.IconTexts = null;
            this.iconTabControl1.ItemSize = new System.Drawing.Size(120, 24);
            this.iconTabControl1.Location = new System.Drawing.Point(0, 0);
            this.iconTabControl1.Name = "iconTabControl1";
            this.iconTabControl1.SelectedIndex = 0;
            this.iconTabControl1.Size = new System.Drawing.Size(677, 458);
            this.iconTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.iconTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage1.Controls.Add(this.cTreeView1);
            this.tabPage1.Controls.Add(this.treeView1);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.menuStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(669, 426);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // cTreeView1
            // 
            this.cTreeView1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(147)))), ((int)(((byte)(49)))));
            this.cTreeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cTreeView1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.cTreeView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cTreeView1.Location = new System.Drawing.Point(240, 122);
            this.cTreeView1.Name = "cTreeView1";
            treeNode15.Name = "节点0";
            treeNode15.Text = "节点0";
            treeNode16.Name = "节点2";
            treeNode16.Text = "节点2";
            treeNode17.Name = "节点1";
            treeNode17.Text = "节点1";
            this.cTreeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode17});
            this.cTreeView1.Size = new System.Drawing.Size(121, 97);
            this.cTreeView1.TabIndex = 3;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(37, 56);
            this.treeView1.Name = "treeView1";
            treeNode18.Name = "节点1";
            treeNode18.Text = "节点1";
            treeNode19.Name = "节点2";
            treeNode19.Text = "节点2";
            treeNode20.Name = "节点0";
            treeNode20.Text = "节点0";
            treeNode21.Name = "节点3";
            treeNode21.Text = "节点3";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21});
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(48, 159);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(92, 23);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(3, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(663, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(669, 426);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(292, 140);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 458);
            this.Controls.Add(this.iconTabControl1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmDemo";
            this.Text = "frmDemo";
            this.iconTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Wfcl.IconTabControl iconTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TreeView treeView1;
        private Common.Wfcl.CTreeView cTreeView1;
    }
}