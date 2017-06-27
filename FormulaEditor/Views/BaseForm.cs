using FormulaEditor.Core;
using FormulaEditor.Core.Controllers;
using FormulaEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaEditor.Views
{
    public class BaseForm:Form
    {

        public AbsWork controller { get; set; }
        public KPINode currentKpi { get; set; }
        public SendMessage send { get; set; }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }
}
