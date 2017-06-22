using FormulaEditor.Model;

namespace FormulaEditor.Core
{
    public interface ICanInitFormulaBody: ICanDo
    {
        void InitFormulaBody(FormulaBody set);
    }
}
