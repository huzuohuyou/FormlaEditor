using FormulaEditor.Core;
using FormulaEditor.Model;
using FormulaEditor.utils;
using System.Collections.Generic;

namespace FormulaEditor
{
    public interface ICallBack:ILog
    {
        void CallBackParams(List<Param> list);
        void RefreshData(KPINode kpi);
    }
}
