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
    public class ShowKPIParams : AbsWork
    {
        public ShowKPIParams(ICanInitKPIParam c):base(c){  }
        public override void Do(string json)
        {
            (can as ICanInitKPIParam).InitKPIParam(JsonConvert.DeserializeObject<List<Param>>(json));
        }
    }
}
