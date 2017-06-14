using FormulaEditor.Core;
using FormulaEditor.Model;
using System.Collections.Generic;

namespace FormulaEditor
{
    public interface ICallBack
    {
        void CallBackParams(List<Param> list);
        void RefreshData(KPINode kpi);
    }
}
