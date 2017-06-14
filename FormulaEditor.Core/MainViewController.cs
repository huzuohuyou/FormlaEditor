﻿using FormulaEditor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulaEditor.Model;

namespace FormulaEditor.Core
{
    public class MainViewController : IMainViewController
    {
        public List<KPINode> GetKPIList()
        {
            List<KPINode> list = new List<KPINode>();
            using (var db = new HJSDR_BJXH_20170303_TESTEntities())
            {
                foreach (var item in db.ED_KPI_INFO)
                {
                    list.Add(new KPINode() {KPI_ID=item.KPI_ID, SD_CODE = item.SD_CODE, KPI_TYPE_CODE = item.KPI_TYPE_CODE, KPI_NAME = item.KPI_NAME });
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
    }
}