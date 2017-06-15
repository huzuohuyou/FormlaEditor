using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Model
{
    public class KPINode
    {
        public int KPI_ID { get; set; }
        public string SD_CODE { get; set; }
        public string KPI_TYPE_CODE { get; set; }
        public string KPI_NAME { get; set; }

        public string ScriptString
        {
            get
            {
                string param = string.Empty, body = string.Empty,note=string.Empty;
                using (var db = new KPIContext())
                {
                    var formula = db.EP_KPI_SET.FirstOrDefault(r => r.KPI_ID == KPI_ID);
                    if (formula.NUM_FORMULA == string.Empty)
                    {
                        body += string.Format(@"result={0}", formula.FRA_FORMULA);
                    }
                    else
                    {
                        body = string.Format(@"if(({0})==1):
    result={1}", formula.NUM_FORMULA, formula.FRA_FORMULA);
                    }
                    body = string.Format("'''\n{0}\n'''\n{1}",formula.KPI_DESC,body);
                }

                using (var db = new HJSDR_BJXH_20170303_TESTEntities())
                {
                    var pyParams = db.EP_KPI_PARAM.ToList<EP_KPI_PARAM>().Where(r => r.KPI_ID == KPI_ID);
                    pyParams.ToList().ForEach(r => { param += string.Format("{0}\n", r.KPI_PARAM_NAME); });
                }
                return string.Format(@"{0}{1}", param, body);
            }
        }
    }
}
