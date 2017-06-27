using FormulaEditor.Model;
using FormulaEditor.Utils.WebApi;

namespace FormulaEditor.Core.Controllers
{
    public abstract class AbsWork : IWork
    {
        public KPINode curKPI { get; set; }
        public ICanDo can { get; private set; }
        public SendMessage send { get; private set; }
        public AbsWork(ICanDo c) : this(c,null) { can = c; }

        public AbsWork(ICanDo c, SendMessage send):this(c,send,null)  { can = c; }

        public AbsWork(ICanDo c, SendMessage send, KPINode k) { can = c; curKPI = k; }

        public abstract void Do(string json);

        public void SendExMsg(string msg)
        {
            (can as ICanConsoleLog)?.log(msg);
            //send(msg);
        }
    }
}
