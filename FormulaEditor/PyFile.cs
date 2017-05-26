using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaEditor
{
    public class PyFile
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }
        public DateTime UpdateTime { get; set; }
        

        public PyFile() {
            
        }

        public List<PyFile> Add(PyFile pyFile) {
            if (File.Exists(pyFile.Path))
            {
                throw new System.Exception(string.Format("{0}文件已存在！", pyFile.Path));
            }
            else
            {
                File.WriteAllText(pyFile.Path, pyFile.Content);
                return new PyList().PList;
            }
        }

        public void Del(PyFile pyFile) {
            if (!File.Exists(pyFile.Path))
            {
                throw new System.Exception(string.Format("{0}文件不存在！", Path));
            }
            else
            {
                File.Delete(pyFile.Path);
            }
        }

        public PyFile Update(PyFile pyFile) {
            if (!File.Exists(pyFile.Path))
            {
                throw new System.Exception(string.Format("{0}文件不存在！", Path));
            }
            else
            {
                File.WriteAllText(pyFile.Path,pyFile.Content);
                return new PyFile() { Name = pyFile.Name, Path = pyFile.Path, Content = File.ReadAllText(Path) };
            }
        }

        public PyFile Query(PyFile  pyFile)
        {
            string path = string.Format(Application.StartupPath + "\\PythonFiles\\{0}", pyFile.Name);
            if (!File.Exists(path))
            {
                throw new System.Exception(string.Format("{0}文件不存在！", Path));
            }
            else
            {
                return new PyFile() { Name = Name, Path = path, Content = File.ReadAllText(path) };
            }
        }
    }
}
