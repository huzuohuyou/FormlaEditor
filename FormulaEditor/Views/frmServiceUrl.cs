using FormulaEditor.Core.Interfaces;
using FormulaEditor.Utils.Config;
using FormulaEditor.Utils.WebApi;
using System;
using System.Windows.Forms;

namespace FormulaEditor.Views
{
    public partial class frmServiceUrl : Form
    {
        ServiceEntity entity;
        ICanRefreshKPIDict irefresh;
        public frmServiceUrl(ICanRefreshKPIDict r)
        {
            irefresh = r;
            InitializeComponent();
            entity = new ServiceEntity { IP = ConfigHelper.GetAppConfig("IP"), Port = ConfigHelper.GetAppConfig("Port") };
            txt_service_url.DataBindings.Add("Text", entity, "Url");
            txt_IP.DataBindings.Add("Text", entity, "IP");
            txt_Port.DataBindings.Add("Text", entity, "Port");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigHelper.UpdateAppConfig("IP",txt_IP.Text.Trim());
            ConfigHelper.UpdateAppConfig("Port", txt_Port.Text.Trim());

            this.FindForm().Close();
            irefresh.RefreshKPIDict();
        }
    }
}
