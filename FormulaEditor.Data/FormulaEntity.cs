﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Model
{
    public class FormulaEntity
    {
        public List<Param> Param { get; set; }
        public FormulaBody Body { get; set; }

    }
}
