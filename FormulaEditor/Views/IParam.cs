using FormulaEditor.Core;

namespace FormulaEditor.Views
{
    public interface IParam
    {
        bool CheckDouble();
        bool CheckDate();
        Param GetParam();
    }
}
