using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Utils.Config
{
    /// <summary>
    /// 当baseUrl不能存在时处理方法
    /// </summary>
    interface IDoWhenNotExist
    {
        void DoWhenNotExist();
    }
}
