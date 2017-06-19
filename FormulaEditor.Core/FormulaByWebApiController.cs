using FormulaEditor.Utils.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaEditor.Model;
using Newtonsoft.Json;

namespace FormulaEditor.Core
{
    public class FormulaByWebApiController : IFormula, IWork
    {
        ICanDo can;
        public FormulaByWebApiController(ICanDo c) { can = c; }

        public void Do(string json)
        {
            (can as ICanInitDataItemDict).InitDataItemDict(JsonConvert.DeserializeObject<List<Param>>(json));
        }

        public void ShowDataItemDict(string sdCode)
        {
            WebApiHelper.doPost("formula/datatiemdict", new Dictionary<string, string>() { { "", sdCode } }, this);
        }
        public void ShowKPIForParams(int kpiId)
        {
            WebApiHelper.doPost("formula/kpiparam", new Dictionary<string, string>() { {"", kpiId.ToString() } }, new ShowKPIParams(can as ICanInitKPIParam));
        }

        public void ShowKPIForBody(int kpiId)
        {
            WebApiHelper.doPost("formula/kpibody", new Dictionary<string, string>() { { "", kpiId.ToString() } }, new ShowKPIForBody(can as ICanInitFormulaBody));
        }

        public Tuple<string, bool> CheckFormula(string script, List<Param> list)
        {
            try
            {
                UsingPython python = new UsingPython(script);
                python.ExcuteScriptFile(list).ToString();
                return new Tuple<string, bool>("语法验证通过！！！", true);
            }
            catch (Exception)
            {
                return new Tuple<string, bool>("语法验证通过！！！", true);
                throw;
            }
        }

        public List<Param> GetDataItemList(string sdCode)
        {
            throw new NotImplementedException();
        }

        public List<Param> GetKPIParams(int kpiId)
        {
            try
            {
                List<Param> list = new List<Param>();
                using (var db = new KPIContext())
                {
                    var query = db.EP_KPI_PARAM.ToList().Where(r => r.KPI_ID == kpiId);
                    query.ToList().ForEach(
                        r => {
                            SD_ITEM_INFO sdi = db.SD_ITEM_INFO.ToList().FirstOrDefault(i => i.SD_ITEM_ID == r.SD_ITEM_ID);
                            list.Add(new Param()
                            {
                                Id = r.ID,
                                DataItemId = r.SD_ITEM_ID,
                                Code = sdi.SD_ITEM_CODE,
                                Name = sdi.SD_ITEM_NAME,
                                DataType = sdi.ITEM_DATA_TYPE
                            });
                        }
                        );
                    return list;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public EP_KPI_SET GetKPIFormulaBody(int kpiId)
        {
            throw new NotImplementedException();
        }

        public int SavaFormulaBody(FormulaBody body)
        {
            try
            {
                WebApiHelper.doPut("formula/kpibody", body, new ShowSaveParamResult(can as ICanShowSaveResult));
                return 1;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int SaveFormulaParam(List<Param> list)
        {
            try
            {
                WebApiHelper.doPut("formula/kpiparam", list, new ShowSaveParamResult(can as ICanShowSaveResult));
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
