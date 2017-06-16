using FormulaEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core
{
    public class RunKPIController : ICalKPIJob
    {
        ICallBack callBack;
        public RunKPIController(ICallBack cb) { callBack = cb; }
        public void Run(string sdCode, string patientId, string KPIId = "")
        {
            try
            {
                using (var db = new KPIContext())
                {
                    db.ED_KPI_INFO.ToList().ForEach(
                        r =>
                        {
                            var body = db.EP_KPI_SET.FirstOrDefault(b => b.KPI_ID == r.KPI_ID);
                            var param = db.EP_KPI_PARAM.ToList().Where(b => b.KPI_ID == r.KPI_ID).ToList();
                            KPIFormula formula = new KPIFormula(body, param);
                            UsingPython python = new UsingPython(formula.KPIScript);
                            callBack.log(python.ExcuteScriptFile(GetParamList(patientId, param)).ToString());
                        //存库.. 
                    }
                        );
                }
            }
            catch (Exception ex)
            {
                callBack.log(ex.ToString());
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
