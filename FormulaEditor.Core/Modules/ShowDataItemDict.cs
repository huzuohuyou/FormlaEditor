using FormulaEditor.Core.Controllers;
using FormulaEditor.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core.Modules
{
    public class ShowDataItemDict : AbsWork
    {
        
        public ShowDataItemDict(ICanInitDataItemDict c): base(c) { }
        public override void Do(string json)
        {
            (can as ICanInitDataItemDict).InitDataItemDict(JsonConvert.DeserializeObject<List<Param>>(json));
        }
    }
}
