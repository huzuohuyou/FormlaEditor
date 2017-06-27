using FormulaEditor.Core;
using FormulaEditor.Utils.WebApi;
using System;
using System.Windows.Forms;

namespace FormulaEditor.Views
{
    public partial class frmLoading : Form, ILoading
    {
        public frmLoading()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            //try
            //{
            //    WebApiHelper.doGet("app/baseinfo",  new ShowKpiScript(can as ICanShowKpiScript));
            //}
            //catch (Exception ex)
            //{
            //    frmServiceUrl frm = new frmServiceUrl();
            //    frm.ShowDialog();
            //}
        }

        public void StopLoading()
        {
            this.FindForm().Close();
        }

        public void OnLoading()
        {
            
            this.Show();
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
            //lb_loading.DataBindings.Add(Text,msg,msg);
            lb_loading.Text = msg;
        }
    }
}
