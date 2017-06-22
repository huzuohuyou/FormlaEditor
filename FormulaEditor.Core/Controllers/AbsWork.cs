using FormulaEditor.Utils.WebApi;

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
