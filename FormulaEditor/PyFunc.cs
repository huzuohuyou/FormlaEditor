using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor
{
    public class PyFunc
    {
        public string FunName { get; set; }
        public PyParam P1 { get; set; }
        public PyParam P2 { get; set; }
        public PyParam P3 { get; set; }
        public PyParam P4 { get; set; }
        public PyParam P5 { get; set; }
        public PyParam P6 { get; set; }
        public PyParam P7 { get; set; }
        public PyParam P8 { get; set; }
        public List<PyParam> listParam = new List<PyParam>();
        public string FunBody { get; set; }
        

        public string CombineFunc() {
            string strFun= "def {0}({1}):\n\t{2}\n\t{3}";
            string param = CombineParam();
            string notes = CombineNotes();
            return string.Format(strFun, FunName, param, notes, FunBody.Replace("\n","\t\n"));
        }

        private string CombineNotes() {
            string notes = "'''\n";
            foreach (var item in listParam)
            {
                notes +=string.Format("\t{0}:{1}\n", item.Key, item.Note);
            }
            notes += "\t'''";
            return notes;
        }

        private string CombineParam() {
            string param = string.Empty;
            foreach (var item in listParam)
            {
                param += item.Key + ",";
            }
            param = param.Trim(',');
            return param;
        }

    }
}
