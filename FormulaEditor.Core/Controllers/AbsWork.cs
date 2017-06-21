using FormulaEditor.Utils.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core.Controllers
{
    public abstract class AbsWork : IWork
    {
        public ICanDo can;
        public AbsWork(ICanDo c) { can = c; }

        public abstract void Do(string json);

        public void SendExMsg(string msg)
        {
            (can as ICanCallBack).log(msg);
        }
    }
}
