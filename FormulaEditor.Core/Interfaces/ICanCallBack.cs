using FormulaEditor.Model;
using FormulaEditor.Utils.WebApi;
using System.Collections.Generic;

namespace FormulaEditor.Core
{
    public interface ICanCallBack :  ICanDo,IWork
    {
        void CallBackParams(List<Param> list);
        void RefreshKpiScript(int kpiid);
        void log(string msg);
    }
}
