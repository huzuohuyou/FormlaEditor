using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormulaEditor
{
    public class PyFile: IEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Templet { get; } = @"# -*- coding:UTF-8 -*-
import sys
import clr
import System
sys.path.append(System.AppDomain.CurrentDomain.BaseDirectory+'\PythonFiles\DLLs')
clr.AddReferenceToFile('Newtonsoft.Json.dll')
from Newtonsoft.Json import *
def method_factory(method_name, p1 = None, p2 = None, p3 = None, p4 = None, p5 = None, p6 = None, p7 = None, p8 = None):
    func = getattr(Foo(), method_name)
    return func(p1, p2, p3, p4, p5, p6, p7, p8)
class Foo :
    def demo(self, p1=None, p2=None, p3=None, p4=None, p5=None, p6=None, p7=None, p8=None):
        return '测试方法'";

        public PyFile() {
            
        }

        public List<PyFile> Add()
        {
            try
            {
                if (File.Exists(Path))
                {
                    throw new System.Exception(string.Format("{0}文件已存在！", Path));
                }
                else
                {
                    InitTemplet();
                    File.WriteAllText(string.Format(Application.StartupPath + "\\PythonFiles\\{0}.py", Name), Content);
                    return new PyFiles().PyList;
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void Del() {
            if (!File.Exists(Path))
            {
                throw new System.Exception(string.Format("{0}文件不存在！", Path ));
            }
            else
            {
                File.Delete(Path);
            }
        }

        public PyFile Update() {
            if (!File.Exists(Path))
            {
                throw new System.Exception(string.Format("{0}文件不存在！", Path));
            }
            else
            {
                File.WriteAllText(Path,Content);
                return new PyFile() { Name = Name, Path = Path, Content = File.ReadAllText(Path) };
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

        public PyFile AddFunc(PyFunc pf) {
            Content +="\n\t"+ pf.CombineContent().Replace("\n","\n\t");
            return Update();
        }

        public void InitTemplet() {
            Content = Templet;
        }

        
    }
}
