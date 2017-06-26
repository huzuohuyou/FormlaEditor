using FormulaEditor.Utils.WebApi;
using System;
using System.Collections.Generic;
using FormulaEditor.Model;
using Newtonsoft.Json;
using FormulaEditor.Core.Controllers;
using FormulaEditor.Core.Modules;

namespace FormulaEditor.Core
{
    public class FormulaByWebApiController : IFormula
    {
        KPINode kpi;
        ICanDo can;
        SendMessage send;
        public FormulaByWebApiController(ICanDo c, SendMessage s, KPINode k) { can = c;send = s;kpi = k; }

        public void ShowDataItemDict(string sdCode)
        {
            try
            {
                WebApiHelper.doPost("formula/datatiemdict", new Dictionary<string, string>() { { "", sdCode } }, new ShowDataItemDict(can as ICanInitDataItemDict));
            }
            catch (Exception ex)
            {
                send(ex.ToString());
            }
        }

        public void ShowKPIForParams(int kpiId)
        {
            try
            {
                WebApiHelper.doPost("formula/kpiparam", new Dictionary<string, string>() { { "", kpiId.ToString() } }, new ShowKPIParams(can as ICanInitKPIParam));

            }
            catch (Exception ex)
            {
                send(ex.ToString());
            }
        }

        public void ShowKPIForBody(int kpiId)
        {
            try
            {
                WebApiHelper.doPost("formula/kpibody", new Dictionary<string, string>() { { "", kpiId.ToString() } }, new ShowKPIForBody(can as ICanInitFormulaBody));

            }
            catch (Exception ex)
            {
                send(ex.ToString());
            }
        }

        public Tuple<string, bool> CheckFormula(string script, List<Param> list)
        {
            try
            {
                UsingPython python = new UsingPython(script);
                python.ExcuteScriptFile(list).ToString();
                return new Tuple<string, bool>("语法验证通过！！！", true);
            }
            catch (Exception ex)
            {
                send(ex.ToString());
                return new Tuple<string, bool>("语法错误！！！", false);
            }
        }

        public void SavaFormulaBody(FormulaBody body ,ICanCallBack callback)
        {
            try
            {
                WebApiHelper.doPut("formula/kpibody", body, callback);
            }
            catch (Exception ex)
            {
                send(ex.ToString());
            }
        }

        public void SaveFormulaParam(List<Param> list, ICanCallBack callback)
        {
            try
            {
                WebApiHelper.doPut("formula/kpiparam", list, callback);
            }
            catch (Exception ex)
            {
                send(ex.ToString());
            }
        }
        
    }
}
