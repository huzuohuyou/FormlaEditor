using System;
using System.Collections.Generic;
using FormulaEditor.Model;
using FormulaEditor.Utils.WebApi;
using Newtonsoft.Json;
using FormulaEditor.Core.Controllers;

namespace FormulaEditor.Core
{
    public class KPIByWebApiController : AbsWork, IKPI
    {

        public KPIByWebApiController(ICanDo c):base(c) {}

        public override void Do(string json)
        {
            try
            {
                (can as ICanInitKPIDict).InitKPIDict(JsonConvert.DeserializeObject<List<KPINode>>(json));
            }
            catch (Exception ex)
            {
                (can as ICallBack).log(ex.Message);
            }
        }

        public void RefreshKpiScript(int kpiId)
        {
            try
            {
                WebApiHelper.doPost("kpi/script", new Dictionary<string, string>() { { "", kpiId.ToString() } }, new ShowKpiScript(can as ICanShowKpiScript));
            }
            catch (Exception ex)
            {
                (can as ICallBack).log(ex.Message);
            }
        }

        public void ShowKPIDict()
        {
            try
            {
                WebApiHelper.doGet("kpi/all", this);
            }
            catch (Exception ex)
            {
                (can as ICallBack).log(ex.Message);
            }
        }
       
    }
}
