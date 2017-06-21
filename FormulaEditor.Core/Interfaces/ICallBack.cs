﻿using FormulaEditor.Core;
using FormulaEditor.Model;
using FormulaEditor.utils;
using System.Collections.Generic;

namespace FormulaEditor.Core
{
    public interface ICanCallBack :  ICanDo
    {
        void CallBackParams(List<Param> list);
        void RefreshKpiScript(int kpiid);
        void log(string msg);
    }
}
