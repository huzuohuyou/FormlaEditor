using FormulaEditor.Model;
using System.Collections.Generic;

namespace FormulaEditor.Core
{
    interface IDataItem
    {
        List<Param> GetDataItemList();

        List<Param> GetKPIDataItemList(int kpiId);

        EP_KPI_SET GetKPIFormulaBody(int kpiId);
    }
}
