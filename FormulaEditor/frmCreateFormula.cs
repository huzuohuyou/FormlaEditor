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

        public List<PyParam> GetParam() {
            List<PyParam> list = new List<PyParam>();
            if (txt_p1.Text!=string.Empty)
            {
                list.Add(new PyParam() {Key="P1",Message= txt_p1.Text });
            }
            else if(txt_p2.Text != string.Empty)
            {
                list.Add(new PyParam() { Key = "P2", Message = txt_p2.Text });
            }
            else if (txt_p3.Text != string.Empty)
            {
                list.Add(new PyParam() { Key = "P3", Message = txt_p3.Text });
            }
            else if (txt_p4.Text != string.Empty)
            {
                list.Add(new PyParam() { Key = "P4", Message = txt_p4.Text });
            }
            else if (txt_p5.Text != string.Empty)
            {
                list.Add(new PyParam() { Key = "P5", Message = txt_p5.Text });
            }
            else if (txt_p6.Text != string.Empty)
            {
                list.Add(new PyParam() { Key = "P6", Message = txt_p6.Text });
            }
            else if (txt_p7.Text != string.Empty)
            {
                list.Add(new PyParam() { Key = "P7", Message = txt_p7.Text });
            }
            else if (txt_p8.Text != string.Empty)
            {
                list.Add(new PyParam() { Key = "P8", Message = txt_p8.Text });
            }

            return list;
        }
    }
}
