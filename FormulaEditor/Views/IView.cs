using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor
{
    public interface IView
    {
        void InitData();
        void RefreshData(IEntity entity);
    }
}
