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
        int SaveFormulaParam(List<Param> list);

        int SavaFormulaBody(FormulaBody body);
        //void RefreshKpiScript(int kPI_ID);
    }
}
