using FormulaEditor.Core.Interfaces;
using FormulaEditor.Model;
using FormulaEditor.Utils.Config;
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
    public partial class frmServiceUrl : Form
    {
        ServiceEntity entity;
        ICanRefreshKPIDict irefresh;
        public frmServiceUrl(ICanRefreshKPIDict r)
        {
            irefresh = r;
            InitializeComponent();
            entity = new ServiceEntity { Url =ConfigHelper.GetAppConfig("BaseUrl") };
            txt_service_url.DataBindings.Add("Text",entity,"Url");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigHelper.UpdateAppConfig("BaseUrl",txt_service_url.Text.Trim());
            this.FindForm().Close();
            irefresh.RefreshKPIDict();
        }
    }
}
