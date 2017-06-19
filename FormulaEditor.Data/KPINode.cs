using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Model
{
    public class KPINode
    {
        public int KPI_ID { get; set; }
        public string SD_CODE { get; set; }
        public string KPI_TYPE_CODE { get; set; }
        public string KPI_NAME { get; set; }
        public int? Status { get; set; }
        public string ScriptString { get; set; }
        
    }
}
