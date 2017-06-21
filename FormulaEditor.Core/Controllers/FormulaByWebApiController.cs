using FormulaEditor.Utils.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaEditor.Model;
using Newtonsoft.Json;
using FormulaEditor.Core.Controllers;

namespace FormulaEditor.Core
{
    public class FormulaByWebApiController : AbsWork,IFormula
    {

        public FormulaByWebApiController(ICanDo c):base(c) { }

        public override void Do(string json)
        {
            try
            {
                (can as ICanInitDataItemDict).InitDataItemDict(JsonConvert.DeserializeObject<List<Param>>(json));
            }
            catch (Exception ex)
            {
                (can as ICanCallBack).log(ex.ToString());
            }
        }

        public void ShowDataItemDict(string sdCode)
        {
            try
            {
                WebApiHelper.doPost("formula/datatiemdict", new Dictionary<string, string>() { { "", sdCode } }, this);

            }
            catch (Exception ex)
            {
                (can as ICanCallBack).log(ex.ToString());
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
                (can as ICanCallBack).log(ex.ToString());
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
                (can as ICanCallBack).log(ex.ToString());
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
                (can as ICanCallBack).log(ex.ToString());
                return new Tuple<string, bool>("语法错误！！！", false);
            }
        }

        public int SavaFormulaBody(FormulaBody body)
        {
            try
            {
                WebApiHelper.doPut("formula/kpibody", body, new ShowSaveParamResult(can as ICanShowSaveResult));
                return 1;
                
            }
            catch (Exception ex)
            {
                (can as ICanCallBack).log(ex.ToString());
                return 0;
            }
        }

        public int SaveFormulaParam(List<Param> list)
        {
            try
            {
                WebApiHelper.doPut("formula/kpiparam", list, new ShowSaveParamResult(can as ICanShowSaveResult));
                return 1;
            }
            catch (Exception ex)
            {
                (can as ICanCallBack).log(ex.ToString());
                return 0;
            }
        }
        
    }
}
