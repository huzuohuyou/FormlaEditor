using FormulaEditor.Utils.WebApi;

namespace FormulaEditor.Core.Controllers
{
    public abstract class AbsWork : IWork
    {
        public ICanDo can;
        SendMessage send;
        public AbsWork(ICanDo c) : this(c,null) { can = c; }

        public AbsWork(ICanDo c, SendMessage send)  { can = c; }

        public abstract void Do(string json);

        public void SendExMsg(string msg)
        {
            (can as ICanCallBack)?.log(msg);
            //send(msg);
        }
    }
}
