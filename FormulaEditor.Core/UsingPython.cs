using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace FormulaEditor.Core
{
    public class UsingPython
    {
        private ScriptRuntime pyRuntime = null;
        ScriptEngine engine = null;
        ScriptScope scope = null;
        private dynamic obj = null;
        string MethodName { get; }
        public UsingPython(string fileName)
        {

            string serverpath = AppDomain.CurrentDomain.BaseDirectory + string.Format("PythonFiles\\{0}",fileName);//所引用python路径
            if (!File.Exists(serverpath))
            {
                throw new Exception(string.Format("{0}文件不存在！",serverpath));
            }
            var options = new Dictionary<string, object>();
            options["Frames"] = true;
            options["FullFrames"] = true;
            ScriptRuntime pyRuntime = Python.CreateRuntime(options);
            obj = pyRuntime.UseFile(serverpath);
        }

        public object ExcutePython(string methodName="",object p1 = null, object p2 = null, object p3 = null, object p4 = null, object p5 = null, object p6 = null, object p7 = null, object p8 = null)
        {
            try
            {
                if (null != obj)
                {
                    Object result = obj.method_factory(methodName, p1, p2, p3, p4, p5, p6, p7, p8);
                    return result;
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<string> GetFunctions() {
            List<string> funList = new List<string>();
            if (null != obj)
            {
                object o= scope.GetItems();
                foreach (var item in scope.GetItems())
                {
                    //Type t=item.GetType();
                    //if (item.Value!=null && item.Value.GetType().Name == "PythonFunction")
                    //{
                    //    funList.Add(item.Key);
                    //}
                    
                }
                return funList;
            }
            return null;
        }
    }
}
