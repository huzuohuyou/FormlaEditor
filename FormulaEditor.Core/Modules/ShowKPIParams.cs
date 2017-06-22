using FormulaEditor.Core.Controllers;
using FormulaEditor.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FormulaEditor.Core
{
    public class ShowKPIParams : AbsWork
    {
        public ShowKPIParams(ICanInitKPIParam c):base(c){  }
        public override void Do(string json)
        {
            (can as ICanInitKPIParam).InitKPIParam(JsonConvert.DeserializeObject<List<Param>>(json));
        }
    }
}
