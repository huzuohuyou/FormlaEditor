using FormulaEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core
{
    public interface ICanSaveFormulaBody:ICanDo
    {
        void SaveFormulaBody(FormulaBody body);
    }
}
