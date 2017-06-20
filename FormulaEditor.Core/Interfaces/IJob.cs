using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core
{
    interface ICalKPIJob
    {
        void Run(string sdCode, string patientId,string KPIId="");
    }
}
