using FormulaEditor.Core.Interfaces;
using FormulaEditor.Utils.WebApi;
using Newtonsoft.Json;
using System;

namespace FormulaEditor.Core.Modules
{
    public class GetKPIResult : IWork
    {
        ICanShowKPIResult can;
        public GetKPIResult(ICanShowKPIResult c) { can = c; }
        public void Do(string json)
        {
            can.ShowKPIResult(json);
        }
    }
}
