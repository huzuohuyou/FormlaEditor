using System.Collections.Generic;

namespace FormulaEditor.Model
{
    public class KpiResultParam
    {
        public string SdCode { get; set; }

        public string KpiId { get; set; }

        public List<string> PatientList { get; set; }
    }
}
