using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor
{
    class UsingPython
    {
        private ScriptRuntime pyRuntime = null;
        private dynamic obj = null;
   
        public UsingPython()
        {
            string serverpath = AppDomain.CurrentDomain.BaseDirectory + "frs_main.py";//所引用python路径
            pyRuntime = Python.CreateRuntime();
            ScriptEngine Engine = pyRuntime.GetEngine("python");
　　　　　//手动设置搜索路径
           ICollection < string > Paths = Engine.GetSearchPaths();
            Paths.Add("//Lib");
            Paths.Add("//Lib//site-packages");
            Paths.Add(AppDomain.CurrentDomain.BaseDirectory + "frs");
            //importpy文件中的库，需要注意先后引用顺序
            Engine.ImportModule("sys");
            Engine.ImportModule("logging");
            Engine.ImportModule("Queue");
            Engine.ImportModule("ctypes");
            Engine.ImportModule("json");
            Engine.ImportModule("os");

            ScriptScope pyScope = Engine.CreateScope(); //Python.ImportModule(Engine, "random");
            obj = Engine.ExecuteFile(serverpath, pyScope);
        }

        public bool ExcutePython()
        {
            try
            {
                if (null != obj)
                {
                    obj.frs_init();//调用frs_main.py中的方法
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
