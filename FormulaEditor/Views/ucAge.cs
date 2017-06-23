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
    [DefaultEvent("TextChanged")]
    public partial class ucAge : Control
    {
        [Browsable(true),
        Bindable(true),
        Category("自定义属性"),
        DefaultValue(22)]
        public int Age { get { return int.Parse(tb_age.Text); } set { tb_age.Text = value.ToString(); } }
        public ucAge()
        {
            InitializeComponent();
        }
        public HorizontalAlignment TextAlign
        {
            get { return tb_age.TextAlign; }
            set { tb_age.TextAlign = value; }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            if (!Controls.Contains(tb_age))
            {
                Controls.Add(tb_age);

            }
        }

       
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        
    }
}
