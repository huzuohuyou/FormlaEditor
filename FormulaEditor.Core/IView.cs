using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Presenter
{
    public interface IView<T> where T : class
    {
        T Model { get; set; }
        void InitData();
        void RefreshData(T entity);
        void BindingData(T model);
    }
}
