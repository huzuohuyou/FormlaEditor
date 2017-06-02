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
        IView view = null;
        PyFile currentPy = null;
        public frmCreateFormula(IView view,PyFile p)
        {
            currentPy= p;
            this.view = view;
            InitializeComponent();
            this.Text =string.Format("{0}_{1}",currentPy.Name.Substring(0, currentPy.Name.LastIndexOf('.')),this.Text);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            PyFunc pf = new PyFunc() { FunName = txt_name.Text.Trim(), listParam = GetParam(), FunBody = rtb_fun.Text ,FunNote = rtb_note.Text.Trim()};
            PyFile pyFile= currentPy.AddFunc(pf);
            view.RefreshData(pyFile);
            this.FindForm().Close();
        }

        public List<PyParam> GetParam()
        {
            List<PyParam> list = new List<PyParam>();
            list.Add(new PyParam() { Key = "p1", Note = txt_p1.Text != string.Empty ? txt_p1.Text : "None" });
            list.Add(new PyParam() { Key = "p2", Note = txt_p2.Text != string.Empty ? txt_p2.Text : "None" });
            list.Add(new PyParam() { Key = "p3", Note = txt_p3.Text != string.Empty ? txt_p3.Text : "None" });
            list.Add(new PyParam() { Key = "p4", Note = txt_p4.Text != string.Empty ? txt_p4.Text : "None" });
            list.Add(new PyParam() { Key = "p5", Note = txt_p5.Text != string.Empty ? txt_p5.Text : "None" });
            list.Add(new PyParam() { Key = "p6", Note = txt_p6.Text != string.Empty ? txt_p6.Text : "None" });
            list.Add(new PyParam() { Key = "p7", Note = txt_p7.Text != string.Empty ? txt_p7.Text : "None" });
            list.Add(new PyParam() { Key = "p8", Note = txt_p8.Text != string.Empty ? txt_p8.Text : "None" });
            return list;
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            PyFunc pf = new PyFunc() { FunName = txt_name.Text.Trim(), listParam = GetParam(),FunBody=rtb_fun.Text ,FunNote=rtb_note.Text};
            MessageBox.Show(pf.CombineContent());
        }
    }
}
