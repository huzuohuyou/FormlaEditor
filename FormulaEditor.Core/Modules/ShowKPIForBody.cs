using FormulaEditor.Core.Controllers;
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
    public class ShowKPIForBody: AbsWork
    {
        public ShowKPIForBody(ICanInitFormulaBody c): base(c) { }
        public override void Do(string json)
        {
            (can as ICanInitFormulaBody).InitFormulaBody(JsonConvert.DeserializeObject<FormulaBody>(json));
        }
    }
}
