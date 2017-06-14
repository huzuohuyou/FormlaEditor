using System;
using System.Windows.Forms;
using FormulaEditor.Views;
using FormulaEditor.Core;
using FormulaEditor.Model;

namespace FormulaEditor
{
    public partial class UCParam : UserControl, IParam
    {
        IManageParam manager;
        public UCParam()
        {
            InitializeComponent();
        }
        public UCParam(IManageParam p)
        {
            InitializeComponent();
            manager = p;
        }

        public bool CheckDate()
        {
            DateTime  result;
            if (DateTime.TryParse(txt_value.Text,out result))
            {
                return true;
            }
            throw new Exception(txt_value.Text+ "无法转换成DateTime类型!");
        }

        public bool CheckDouble()
        {
            double result;
            if (double.TryParse(txt_value.Text, out result))
            {
                return true;
            }
            throw new Exception(txt_value.Text + "无法转换成double类型!");
        }

        public Param GetParam()
        {
            try
            {
                CheckType();
                return new Param()
                {
                    Name = txt_name.Text,
                    Value = txt_value.Text,
                    DataType = cmb_type.Text
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckType()
        {
            if (cmb_type.Text == "double")
            {
                return CheckDouble();
            }
            else if (cmb_type.Text == "datetime")
            {
                return CheckDate();
            }
            else if (cmb_type.Text == "string")
            {
                return true;
            }
            else
            {
                throw new Exception("un know type");
            }
        }

        private void cmb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manager.AddParam();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            manager.DelParam();
        }
    }
}
