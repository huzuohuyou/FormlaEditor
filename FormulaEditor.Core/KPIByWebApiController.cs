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

        ICanInitKPIDict can;


        public KPIByWebApiController(ICanInitKPIDict c) { this.can = c; }

        public void Do(string json)
        {
            can.InitKPIDict(JsonConvert.DeserializeObject<List<KPINode>>(json));
        }

        public List<KPINode> GetKPIList()
        {
            
            throw new NotImplementedException();
        }

        public void RefreshKPIList()
        {
            throw new NotImplementedException();
        }

        public void ShowKPIDict()
        {
            WebApiHelper.doGet("kpi/all", this);
        }

       
    }
}
