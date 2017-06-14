using FormulaEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core
{
    public interface IMainViewController
    {
        string GetScript(KPINode kpi);
        List<KPINode> GetKPIList();
        void RefreshKPIList();
    }
}
