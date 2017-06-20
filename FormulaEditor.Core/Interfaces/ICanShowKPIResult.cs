using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core.Interfaces
{
    public interface ICanShowKPIResult : ICanDo
    {
        void ShowKPIResult(string result);
    }
}
