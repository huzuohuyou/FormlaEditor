using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaEditor
{
    public partial class frmCreateFormula : Form
    {
        PyFile currentPy = null;
        public frmCreateFormula(PyFile p)
        {
            currentPy= p;
            InitializeComponent();
            this.Text =string.Format("{0}_{1}",currentPy.Name.Substring(0, currentPy.Name.LastIndexOf('.')),this.Text);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            PyFunc pf = new PyFunc() { FunName = txt_name.Text,listParam=GetParam()};

        }

        public List<PyParam> GetParam()
        {
            List<PyParam> list = new List<PyParam>();
            if (txt_p1.Text.Trim() != string.Empty)
            {
                list.Add(new PyParam() { Key = "p1", Note = txt_p1.Text });
            }
            if (txt_p2.Text.Trim() != string.Empty)
            {
                list.Add(new PyParam() { Key = "p2", Note = txt_p2.Text });
            }
            if (txt_p3.Text.Trim() != string.Empty)
            {
                list.Add(new PyParam() { Key = "p3", Note = txt_p3.Text });
            }
            if (txt_p4.Text.Trim() != string.Empty)
            {
                list.Add(new PyParam() { Key = "p4", Note = txt_p4.Text });
            }
            if (txt_p5.Text.Trim() != string.Empty)
            {
                list.Add(new PyParam() { Key = "p5", Note = txt_p5.Text });
            }
            if (txt_p6.Text.Trim() != string.Empty)
            {
                list.Add(new PyParam() { Key = "p6", Note = txt_p6.Text });
            }
            if (txt_p7.Text.Trim() != string.Empty)
            {
                list.Add(new PyParam() { Key = "p7", Note = txt_p7.Text });
            }
            if (txt_p8.Text.Trim() != string.Empty)
            {
                list.Add(new PyParam() { Key = "p8", Note = txt_p8.Text });
            }

            return list;
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            PyFunc pf = new PyFunc() { FunName = txt_name.Text.Trim(), listParam = GetParam(),FunBody=rtb_fun.Text };
            string strFun=pf.CombineFunc();
            MessageBox.Show(strFun);
        }
    }
}
