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
        public string FunNote { get; set; }
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
        //public string Content { get; set; }
        public PyFunc()
        {
            //Content = CombineFunc();
        }


        public string CombineContent() {
            string strFun= "def {0}({1}):\n\t{2}\n\t{3}";
            string param = CombineParam();
            string notes = CombineNotes();
            return string.Format(strFun, FunName, param, notes, FunBody.Replace("\n","\n\t"));
        }

        private string CombineNotes() {
            string notes =string.Format("\n\t#{0}\n",FunNote.Replace("\n","").Replace("\t",""));
            foreach (var item in listParam)
            {
                notes +=string.Format("\t#{0}:{1}\n", item.Key, item.Note);
            }
            notes = notes.Trim();
            return notes;
        }

        private string CombineParam() {
            //string param = "self,";
            //foreach (var item in listParam)
            //{
            //    param +=string.Format("{0},", item.Key);
            //}
            //param = param.Trim(',');
            //return param;
            return "self,p1=None,p2=None,p3=None,p4=None,p5=None,p6=None,p7=None,p8=None";
        }

    }
}
