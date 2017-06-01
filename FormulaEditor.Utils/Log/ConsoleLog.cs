using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaEditor.utils
{
    public class ConsoleLog : ILog
    {
        RichTextBox textbox = null;
        public ConsoleLog(RichTextBox textbox) {
            this.textbox = textbox;
        }
        public void log(string msg)
        {
            textbox.Text = string.Format("{0} : {1}\n",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),msg)+ textbox.Text ;
        }
    }
}
