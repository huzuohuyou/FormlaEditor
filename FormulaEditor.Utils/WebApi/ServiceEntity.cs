namespace FormulaEditor.Utils.WebApi
{
    public class ServiceEntity
    {
        public string Url { get { return string.Format("http://{0}:{1}//", IP,Port); } }

        public string IP { get; set; }

        public string Port { get; set; }
    }
}
