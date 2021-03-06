﻿using System;
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
    public partial class frmCreateSingel : Form
    {
        IView view = null;
        public frmCreateSingel(IView v)
        {
            view = v;
            InitializeComponent();
        }

        private void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                PyFile pf = new PyFile() { Name = txt_name.Text };
                pf.Add();
                view.InitData();
                this.FindForm().Close();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
