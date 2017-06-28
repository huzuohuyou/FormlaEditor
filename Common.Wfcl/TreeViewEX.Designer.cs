namespace Common.Wfcl
{
    partial class TreeViewEX
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewEX));
            this.arrowImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // arrowImageList
            // 
            this.arrowImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("arrowImageList.ImageStream")));
            this.arrowImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.arrowImageList.Images.SetKeyName(0, "1.png");
            this.arrowImageList.Images.SetKeyName(1, "2.png");
            this.arrowImageList.Images.SetKeyName(2, "3.png");
            this.arrowImageList.Images.SetKeyName(3, "4.png");
            // 
            // TreeViewEX
            // 
            this.LineColor = System.Drawing.Color.Black;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList arrowImageList;
    }
}
