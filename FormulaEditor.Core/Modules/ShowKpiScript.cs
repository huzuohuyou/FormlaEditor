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
    public class ShowKpiScript : AbsWork
    {

        public ShowKpiScript(ICanShowKpiScript c):base(c){}

        public override void Do(string json)
        {
            (can as ICanShowKpiScript).ShowKpiScript(JsonConvert.DeserializeObject<KPINode>(json).ScriptString);
        }
    }
}
