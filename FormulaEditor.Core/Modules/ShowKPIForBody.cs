using FormulaEditor.Model;
using FormulaEditor.Utils.WebApi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core
{
    public class ShowKPIForBody: IWork
    {
        ICanInitFormulaBody can;
        public ShowKPIForBody(ICanInitFormulaBody c) { can = c; }
        public void Do(string json)
        {
            can.InitFormulaBody(JsonConvert.DeserializeObject<FormulaBody>(json));
        }
    }
}
