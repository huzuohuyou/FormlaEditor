﻿namespace FormulaEditor.Views
{
    partial class ucDataItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.lb_type = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_dataItem = new System.Windows.Forms.Label();
            this.btn_del = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类型:";
            // 
            // lb_type
            // 
            this.lb_type.AutoSize = true;
            this.lb_type.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_type.Location = new System.Drawing.Point(44, 7);
            this.lb_type.Name = "lb_type";
            this.lb_type.Size = new System.Drawing.Size(41, 12);
            this.lb_type.TabIndex = 1;
            this.lb_type.Text = "______";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(91, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据项:";
            // 
            // lb_dataItem
            // 
            this.lb_dataItem.AutoSize = true;
            this.lb_dataItem.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_dataItem.Location = new System.Drawing.Point(144, 7);
            this.lb_dataItem.Name = "lb_dataItem";
            this.lb_dataItem.Size = new System.Drawing.Size(71, 12);
            this.lb_dataItem.TabIndex = 3;
            this.lb_dataItem.Text = "___________";
            this.lb_dataItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_del
            // 
            this.btn_del.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_del.Location = new System.Drawing.Point(221, 2);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(27, 23);
            this.btn_del.TabIndex = 4;
            this.btn_del.Text = "X";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // ucDataItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.lb_dataItem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_type);
            this.Controls.Add(this.label1);
            this.Name = "ucDataItem";
            this.Size = new System.Drawing.Size(256, 26);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_dataItem;
        private System.Windows.Forms.Button btn_del;
    }
}