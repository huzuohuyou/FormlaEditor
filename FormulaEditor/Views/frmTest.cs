using FormulaEditor.Core;
using FormulaEditor.Core.Interfaces;
using FormulaEditor.Model;
using FormulaEditor.Views;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace FormulaEditor
{
    public partial class frmTest : BaseForm, IManageParam, ICanTestFormula
    {
        private UCParam ucParam1;
        private UCParam ucParam2;
        private UCParam ucParam3;
        List<UCParam> uclist;

        public frmTest(SendMessage s, KPINode currentKpi)
        {
            this.currentKpi = currentKpi;
            InitializeComponent();
            this.send = s;
            InitUCParam();
            uclist = new List<UCParam>() { ucParam1, ucParam2, ucParam3 };
        }

        public void InitUCParam()
        {
            this.ucParam1 = new FormulaEditor.UCParam(this);
            this.ucParam1.Location = new System.Drawing.Point(0, 42);
            this.ucParam1.Name = "ucParam1";
            this.ucParam1.Size = new System.Drawing.Size(441, 30);
            this.ucParam1.TabIndex = 8;
            this.Controls.Add(this.ucParam1);
            //--
            this.ucParam2 = new FormulaEditor.UCParam(this);
            this.ucParam2.Location = new System.Drawing.Point(0, 42 + 30);
            this.ucParam2.Name = "ucParam1";
            this.ucParam2.Size = new System.Drawing.Size(441, 30);
            this.ucParam2.TabIndex = 8;
            this.Controls.Add(this.ucParam2);
            //-
            this.ucParam3 = new FormulaEditor.UCParam(this);
            this.ucParam3.Location = new System.Drawing.Point(0, 42 + 30 * 2);
            this.ucParam3.Name = "ucParam1";
            this.ucParam3.Size = new System.Drawing.Size(441, 30);
            this.ucParam3.TabIndex = 8;
            this.Controls.Add(this.ucParam3);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            List<Param> list = new List<Param>();
            uclist.ForEach(r =>
            {
                list.Add(r.GetParam());
            });

            TestFormula(list);
        }

        public void AddParam()
        {
            UCParam p = new UCParam(this);
            p.Location = new Point(0, 42 + 30 * uclist.Count);
            uclist.Add(p);
            this.Controls.Add(p);
            this.Height = this.Height + 30;
        }

        public void DelParam()
        {
            if (uclist.Count > 1)
            {
                UCParam uc = uclist[uclist.Count - 1];
                uclist.Remove(uc);
                this.Height = this.Height - 30;
                this.Controls.Remove(uc);
            }

        }

        public void TestFormula(List<Param> list)
        {
            UsingPython python = new UsingPython(currentKpi);
            send(python.ExcuteScriptFile(list).ToString());
        }
    }
}
