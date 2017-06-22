namespace FormulaEditor.Views
{
    public interface ILoading
    {
        void StopLoading();
        void OnLoading();
        void SendLoadingInfo(string msg);
    }
}
