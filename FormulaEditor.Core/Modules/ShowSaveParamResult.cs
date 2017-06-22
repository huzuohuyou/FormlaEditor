using FormulaEditor.Core.Controllers;

namespace FormulaEditor.Core
{
    public class ShowSaveParamResult : AbsWork
    {

        public ShowSaveParamResult(ICanShowSaveResult c) : base(c) { }

        public override void Do(string json)
        {
            (can as ICanShowSaveResult).ShowResult(json);
        }
    }
}
