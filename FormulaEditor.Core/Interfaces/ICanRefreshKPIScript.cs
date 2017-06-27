using FormulaEditor.Utils.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core.Interfaces
{
    public interface ICanRefreshKPIScript : ICanDo
    {
        void RefreshKpiScript(int kpiid);
    }
}
