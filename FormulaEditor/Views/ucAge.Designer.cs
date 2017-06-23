namespace FormulaEditor.Views
{
    partial class ucAge
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_age = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tb_age
            // 
            this.tb_age.Dock = System.Windows.Forms.DockStyle.Left;
            this.tb_age.Location = new System.Drawing.Point(0, 0);
            this.tb_age.Name = "tb_age";
            this.tb_age.Size = new System.Drawing.Size(100, 21);
            this.tb_age.TabIndex = 0;
            this.tb_age.Text = "22";
            // 
            // ucAge
            // 
            this.Size = new System.Drawing.Size(100, 28);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tb_age;
    }
}
