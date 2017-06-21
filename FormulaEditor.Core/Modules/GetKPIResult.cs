using FormulaEditor.Core.Controllers;
using FormulaEditor.Core.Interfaces;

namespace FormulaEditor.Core.Modules
{
    public class GetKPIResult : AbsWork
    {
        public GetKPIResult(ICanShowKPIResult c):base(c) {  }
        public override void Do(string json)
        {
            (can as ICanShowKPIResult).ShowKPIResult(json);
        }
    }
}
