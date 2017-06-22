namespace FormulaEditor.Utils.WebApi
{
    public interface IWork
    {
        void Do(string json);
        void SendExMsg(string msg);
    }
}
