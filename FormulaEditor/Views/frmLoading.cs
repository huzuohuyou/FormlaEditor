using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaEditor.Views
{
    public partial class frmLoading : Form, ILoading
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {

        }

        public void StopLoading()
        {
            this.Close();
        }

        public void OnLoading()
        {
            
            this.ShowDialog();
            SendLoadingInfo("..loading this.");
            SendLoadingInfo("..loading that.");
            SendLoadingInfo("..loading the other.");
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            StopLoading();
        }

        public void SendLoadingInfo(string msg)
        {
            lb_loading.Text = msg;
        }
    }
}
