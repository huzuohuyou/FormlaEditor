using FormulaEditor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaEditor.Model;

namespace FormulaEditor.Core
{
    public class KPIByEFController : IKPI
    {
        public List<KPINode> GetKPIList()
        {
            List<KPINode> list = new List<KPINode>();
            using (var db = new KPIContext())
            {
                foreach (var item in db.ED_KPI_INFO)
                {
                    list.Add(new KPINode() {
                        KPI_ID = item.KPI_ID,
                        SD_CODE = item.SD_CODE,
                        KPI_TYPE_CODE = item.KPI_TYPE_CODE,
                        KPI_NAME = item.KPI_NAME,
                        Status = db.EP_KPI_SET.FirstOrDefault(r =>  r.KPI_ID == item.KPI_ID )?.INVALID_FLAG
                        });
                }

            }
            return list;
        }

        public void RefreshKPIList()
        {
            throw new NotImplementedException();
        }

        public string GetScript(KPINode kpi)
        {
            throw new NotImplementedException();
        }

        public void ShowKPIDict()
        {
            throw new NotImplementedException();
        }

        public void RefreshKpiScript(int kpiId)
        {
            throw new NotImplementedException();
        }
    }
}
