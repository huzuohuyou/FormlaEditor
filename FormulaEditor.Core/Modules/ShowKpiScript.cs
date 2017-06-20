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
    public class ShowKpiScript : IWork
    {
        private ICanShowKpiScript canShowKpiScript;

        public ShowKpiScript(ICanShowKpiScript canShowKpiScript)
        {
            this.canShowKpiScript = canShowKpiScript;
        }

        public void Do(string json)
        {
            canShowKpiScript.ShowKpiScript(JsonConvert.DeserializeObject<KPINode>(json).ScriptString);
        }
    }
}
