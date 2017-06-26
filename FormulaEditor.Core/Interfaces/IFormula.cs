using FormulaEditor.Model;
using System;
using System.Collections.Generic;

namespace FormulaEditor.Core
{
    public interface IFormula
    {



        Tuple<string, bool> CheckFormula(string script, List<Param> list);

        void ShowDataItemDict(string sdCode);

        void ShowKPIForParams(int kpiId);

        void ShowKPIForBody(int kpiId);

        void SaveFormulaParam(List<Param> list, ICanCallBack callback);

        //int SavaFormulaBody(FormulaBody body);
        void SavaFormulaBody(FormulaBody formulaBody, ICanCallBack callback);
        //void RefreshKpiScript(int kPI_ID);
    }
}
