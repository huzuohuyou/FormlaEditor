using FormulaEditor.Model;
using FormulaEditor.Utils.WebApi;

namespace FormulaEditor.Core.Controllers
{
    public abstract class AbsWork : IWork
    {
        public KPINode curKPI { get; set; }
        public ICanDo can { get;  set; }
        public SendMessage send { get;  set; }
        public AbsWork(ICanDo c) : this(c,null) {  }

        public AbsWork(ICanDo c, SendMessage s):this(c,s,null)  { }

        public AbsWork(ICanDo c, SendMessage s, KPINode k) { can = c; curKPI = k;send = s; }

        public abstract void Do(string json);

        public void SendExMsg(string msg)
        {
            (can as ICanConsoleLog)?.log(msg);
            //send(msg);
        }
    }
}
