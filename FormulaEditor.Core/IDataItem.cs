using FormulaEditor.Model;
using System;
using System.Collections.Generic;

namespace FormulaEditor.Core
{
    interface IDataItem
    {
        List<Param> GetDataItemList();

        List<Param> GetKPIDataItemList(int kpiId);

        EP_KPI_SET GetKPIFormulaBody(int kpiId);

        Tuple<string, bool> CheckFormula(string script, List<Param> list);
    }
}
