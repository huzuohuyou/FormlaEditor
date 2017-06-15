using System;
using System.Collections.Generic;
using FormulaEditor.Model;
using System.Linq;

namespace FormulaEditor.Core
{
    public class CreateFormulaController : IDataItem
    {
        public List<Param> GetDataItemList()
        {
            try
            {
                List<Param> list = new List<Param>();
                using (var db = new HJSDR_BJXH_20170303_TESTEntities())
                {
                    var dataItems = db.SD_ITEM_INFO.ToList().Where(r => r.SD_CODE == "1");
                    dataItems.ToList().ForEach(r => { list.Add(new Param() {Id=r.SD_ITEM_ID,Code=r.SD_ITEM_CODE, Name = r.SD_ITEM_NAME,Type=r.ITEM_TYPE_CODE, DataType = r.DATA_TYPE }); });
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveFormulaParam(List<EP_KPI_PARAM> list)
        {
            try
            {
                using (var db = new KPIContext())
                {
                    list.ForEach(r =>
                    {
                        db.EP_KPI_PARAM.Add(r);
                    }
                    );
                    return db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public int SavaFormulaBody(EP_KPI_SET body)
        {
            try
            {
                using (var db = new KPIContext())
                {
                    db.EP_KPI_SET.Add(body);
                    return db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
