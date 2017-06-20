using System;
using System.Collections.Generic;
using FormulaEditor.Model;
using System.Linq;

namespace FormulaEditor.Core
{
    public class FormulaByEFController : IFormula
    {
        public List<Param> GetDataItemList(string sdCode)
        {
            try
            {
                List<Param> list = new List<Param>();
                using (var db = new HJSDR_BJXH_20170303_TESTEntities())
                {
                    var dataItems = db.SD_ITEM_INFO.ToList().Where(r => r.SD_CODE == sdCode);
                    dataItems.ToList().ForEach(r => { list.Add(new Param() {DataItemId=r.SD_ITEM_ID,Code=r.SD_ITEM_CODE, Name = r.SD_ITEM_NAME,Type=r.ITEM_TYPE_CODE, DataType = r.ITEM_DATA_TYPE }); });
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
                    db.EP_KPI_PARAM.ToList().Where(r=>r.KPI_ID== list[0].KPI_ID).ToList().ForEach(r=> {
                        db.EP_KPI_PARAM.Remove(r);
                    });
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
                    db.EP_KPI_SET.ToList().Where(r => r.KPI_ID == body.KPI_ID).ToList().ForEach(r => {
                        db.EP_KPI_SET.Remove(r);
                    });
                    db.EP_KPI_SET.Add(body);
                    return db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public List<Param> GetKPIParams(int kpiId)
        {
            try
            {
                List<Param> list = new List<Param>();
                using (var db = new KPIContext())
                {
                    var query=db.EP_KPI_PARAM.ToList().Where(r=>r.KPI_ID==kpiId);
                    query.ToList().ForEach(
                        r => {
                            SD_ITEM_INFO sdi = db.SD_ITEM_INFO.ToList().FirstOrDefault(i => i.SD_ITEM_ID == r.SD_ITEM_ID);
                            list.Add(new Param() {
                                Id=r.ID,
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
            try
            {
                using (var db = new KPIContext())
                {
                    var query = db.EP_KPI_SET.FirstOrDefault(r => r.KPI_ID == kpiId);
                    return query;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Tuple< string,bool> CheckFormula(string script, List<Param> list)
        {
            try
            {
                UsingPython python = new UsingPython(script);
                python.ExcuteScriptFile(list).ToString();
                return new Tuple<string, bool>("语法验证通过！！！", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ShowDataItemDict(string sdCode)
        {
            throw new NotImplementedException();
        }

        public void ShowKPIForParams(int kpiId)
        {
            throw new NotImplementedException();
        }

        public void ShowKPIForBody(int kpiId)
        {
            throw new NotImplementedException();
        }

        public int SaveFormulaParam(List<Param> list)
        {
            throw new NotImplementedException();
        }

        public int SavaFormulaBody(FormulaBody body)
        {
            throw new NotImplementedException();
        }
    }
}
