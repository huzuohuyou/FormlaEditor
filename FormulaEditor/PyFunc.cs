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

        

        public string OutPut() {
            string header= "def {0}({1})";
            string param = string.Empty;
            foreach (var item in listParam)
            {
                param += item.Key+",";
            }
            param = param.Trim(',');
            header = string.Format(header, FunName, param);
            return  header + "\n\t" + FunBody;
        }

    }
}
