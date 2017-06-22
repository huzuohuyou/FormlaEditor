using FormulaEditor.Core.Controllers;
using FormulaEditor.Model;
using Newtonsoft.Json;

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
