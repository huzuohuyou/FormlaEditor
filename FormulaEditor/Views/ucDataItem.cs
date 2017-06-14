using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormulaEditor.Model;

namespace FormulaEditor.Views
{
    public partial class ucDataItem : UserControl
    {
        ICanClear continer;
        Param param;
        public ucDataItem(ICanClear c,Param p)
        {
            continer = c;
            param = p;
            InitializeComponent();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            continer.RemoveDataItem(this);
        }
    }
}
