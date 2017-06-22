using FormulaEditor.Model;
using System.Collections.Generic;

namespace FormulaEditor.Core
{
    public interface ICanInitKPIDict: ICanDo
    {
        void InitKPIDict(List<KPINode> list);
    }
}
