using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core
{
    public interface ICanRefreshSavParameResult:ICanDo
    {
        void RefreshSavParameResult(string msg);
    }
}
