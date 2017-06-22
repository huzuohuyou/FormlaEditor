using FormulaEditor.Core.Controllers;
using FormulaEditor.Model;
using Newtonsoft.Json;

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
