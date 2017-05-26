using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaEditor
{
    public class PyList
    {
        public List<PyFile> PList = new List<PyFile>();
        public PyList() {
            string pythonDir = string.Format("{0}\\PythonFiles", Application.StartupPath);
            if (!Directory.Exists(pythonDir))
            {
                Directory.CreateDirectory(pythonDir);
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(pythonDir);
                FileInfo[] fi = di.GetFiles();
                foreach (var item in fi)
                {
                    PyFile pf = new PyFile() {Name=item.Name,Path = item.FullName,Content = File.ReadAllText(item.FullName) };
                    PList.Add(pf);
                }
            }
        }
    }
}
