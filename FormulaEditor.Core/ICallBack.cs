﻿using FormulaEditor.Core;
using FormulaEditor.Model;
using FormulaEditor.utils;
using System.Collections.Generic;

namespace FormulaEditor.Core
{
    public interface ICallBack:ILog
    {
        void CallBackParams(List<Param> list);
        void RefreshKpiScript(int kpiid);
    }
}
