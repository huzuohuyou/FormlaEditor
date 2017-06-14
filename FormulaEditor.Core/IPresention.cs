using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Core
{
    interface IPresention<T> where T : class
    {
        int InsertData(T model);
        void UpdateData(T model);
        void DeleteData(T model);
    }
}
