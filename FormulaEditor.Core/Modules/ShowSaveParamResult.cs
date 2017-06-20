using FormulaEditor.Utils.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core
{
    public class ShowSaveParamResult : IWork
    {
        private ICanShowSaveResult canShowSaveResult;

        public ShowSaveParamResult(ICanShowSaveResult canShowSaveResult)
        {
            this.canShowSaveResult = canShowSaveResult;
        }

        public void Do(string json)
        {
            canShowSaveResult.ShowResult(json);
        }
    }
}
