using FormulaEditor.Core.Controllers;
using FormulaEditor.Model;

namespace FormulaEditor.Core
{
    public class ShowSaveParamResult : AbsWork
    {
        

        public ShowSaveParamResult(ICanDo c) : base(c)
        {
        }

        public ShowSaveParamResult(ICanRefreshSavParameResult c, KPINode node) : base(c,null,node) { }

        public override void Do(string json)
        {
            (can as ICanRefreshSavParameResult).RefreshSavParameResult(json);
        }
    }
}
