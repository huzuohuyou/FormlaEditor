using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaEditor.Model;
using FormulaEditor.Utils.WebApi;
using Newtonsoft.Json;

namespace FormulaEditor.Core
{
    public class KPIByWebApiController : IKPI,IWork
    {

        ICanDo can;

        public KPIByWebApiController(ICanDo c) { this.can = c; }

        public void Do(string json)
        {
            (can as ICanInitKPIDict).InitKPIDict(JsonConvert.DeserializeObject<List<KPINode>>(json));
        }

        public List<KPINode> GetKPIList()
        {
            
            throw new NotImplementedException();
        }

        public void RefreshKPIList()
        {
            throw new NotImplementedException();
        }

        public void RefreshKpiScript(int kpiId)
        {
            WebApiHelper.doPost("kpi/script",new Dictionary<string, string>() { { "", kpiId.ToString() } }, new ShowKpiScript(can as ICanShowKpiScript));
        }

        public void ShowKPIDict()
        {
            WebApiHelper.doGet("kpi/all", this);
        }

       
    }
}
