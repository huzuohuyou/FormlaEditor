using FormulaEditor.Core.Interfaces;
using FormulaEditor.Core.Modules;
using FormulaEditor.Model;
using FormulaEditor.Utils.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FormulaEditor.Core
{
    public class RunKPIController : ICalKPIJob
    {
        ICanDo can;

        public RunKPIController(ICanDo cb) { can = cb; }

        public void Run(string sdCode, List<string> pList, string KPIId = "")
        {
            try
            {
                WebApiHelper.doPost("kpiresult/sdcode",new KpiResultParam() {SdCode =sdCode,KpiId=KPIId,PatientList= pList }, new GetKPIResult(can as ICanShowKPIResult));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Param> GetParamList(string patientId, List<EP_KPI_PARAM> ep_kpi_param_List)
        {
            List<Param> result = new List<Param>();
            ep_kpi_param_List.ForEach(
                r =>
                {
                    using (var db = new KPIContext())
                    {
                        var sd_item_info = db.SD_ITEM_INFO.FirstOrDefault(m => m.SD_ITEM_ID == r.SD_ITEM_ID);
                        result.Add(new Param()
                        {
                            Code = sd_item_info.SD_ITEM_CODE,
                            Name = sd_item_info.SD_ITEM_CODE,
                            DataType = sd_item_info.ITEM_DATA_TYPE,
                            Value = GetParamValue(sd_item_info, patientId)
                        });
                    }
                }
                );
            return result;
        }

        public dynamic GetParamValue(SD_ITEM_INFO sd_item_info, string patient_id)
        {
            using (var db = new KPIContext())
            {
                return db.PAT_SD_ITEM_RESULT.FirstOrDefault(r =>
                r.SD_CODE == sd_item_info.SD_CODE.Trim()
                && r.SD_ITEM_CODE == sd_item_info.SD_ITEM_CODE.Trim()
                && r.PATIENT_ID == patient_id)?.SD_ITEM_VALUE;
            }
        }
    }
}
