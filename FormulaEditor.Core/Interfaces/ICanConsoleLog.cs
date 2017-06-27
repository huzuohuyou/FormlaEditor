using FormulaEditor.Model;
using FormulaEditor.Utils.WebApi;
using System.Collections.Generic;

namespace FormulaEditor.Core
{
    public interface ICanConsoleLog :  ICanDo
    {
        
        void log(string msg);
    }
}
