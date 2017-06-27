using FormulaEditor.Core.Controllers;
using FormulaEditor.Core.Interfaces;
using FormulaEditor.Model;
using Newtonsoft.Json;

namespace FormulaEditor.Core.Modules
{
    public class RefreshKPIScript : AbsWork
    {
        public RefreshKPIScript(ICanRefreshKPIScript c): base(c) { }
        public override void Do(string json)
        {
            (can as ICanRefreshKPIScript).RefreshKpiScript(int.Parse(JsonConvert.DeserializeObject<FormulaEntity>(json).Body.KPIId));
        }
    }
}
