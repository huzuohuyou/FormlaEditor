using FormulaEditor.Core;
using FormulaEditor.Model;

namespace FormulaEditor.Views
{
    public interface IParam
    {
        bool CheckDouble();
        bool CheckDate();
        Param GetParam();
    }
}
