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
    public class ShowKPIParams : IWork
    {
        ICanInitKPIParam can;
        public ShowKPIParams(ICanInitKPIParam c) { can = c; }
        public void Do(string json)
        {
            can.InitKPIParam(JsonConvert.DeserializeObject<List<Param>>(json));
        }
    }
}
