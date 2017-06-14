using FormulaEditor.Model;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.IO;

namespace FormulaEditor.Core
{
    public class UsingPython
    {
        ScriptEngine engine ;
        ScriptScope scope ;
        ScriptSource source;
        private UsingPython() { }
        public UsingPython(string fileName)
        {

            var serverpath = AppDomain.CurrentDomain.BaseDirectory + string.Format("PythonFiles\\{0}", fileName);//所引用python路径
            if (!File.Exists(serverpath))
            {
                throw new Exception(string.Format("{0}文件不存在！", serverpath));
            }
            engine = Python.CreateEngine();
            scope = engine.CreateScope();
            source = engine.CreateScriptSourceFromFile(serverpath);
        }

        public UsingPython(KPINode kpi)
        {
            engine = Python.CreateEngine();
            scope = engine.CreateScope();
            source = engine.CreateScriptSourceFromString(kpi.ScriptString);
        }
        public object ExcuteScriptString(string pyContent, List<Param> paramList)
        {
            try
            {
                var engine = Python.CreateEngine();
                var scope = engine.CreateScope();
                var source = engine.CreateScriptSourceFromString(pyContent);
                foreach (var item in paramList)
                {
                    scope.SetVariable(item.Name, item.FixValue);
                }
                source.Execute(scope);
                return scope.GetVariable("result").ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object ExcuteScriptFile(List<Param> paramList)
        {
            try
            {
                scope.SetVariable("result", "");
                foreach (var item in paramList)
                {
                    scope.SetVariable(item.Name, item.FixValue);
                }
                source.Execute(scope);
                return scope.GetVariable("result").ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       
    }
}
