using FormulaEditor.Core.Controllers;
using FormulaEditor.Utils.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core
{
    public class ShowSaveParamResult : AbsWork
    {

        public ShowSaveParamResult(ICanShowSaveResult c) : base(c) { }

        public override void Do(string json)
        {
            (can as ICanShowSaveResult).ShowResult(json);
        }
    }
}
