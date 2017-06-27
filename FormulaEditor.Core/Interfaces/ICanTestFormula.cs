using FormulaEditor.Model;
using System.Collections.Generic;

namespace FormulaEditor.Core.Interfaces
{
    public interface ICanTestFormula:ICanDo
    {
        void TestFormula(List<Param> list);
    }
}
