using FormulaEditor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Presenter
{
    public class MainFormPresentation : IPresention<ED_KPI_INFO>
    {
        IView<ED_KPI_INFO> view;

        public MainFormPresentation(IView<ED_KPI_INFO> view) {
            this.view = view;
        }
        public void DeleteData(ED_KPI_INFO model)
        {
            throw new NotImplementedException();
        }

        public void InsertData(ED_KPI_INFO model)
        {
            throw new NotImplementedException();
        }

        public void UpdateData(ED_KPI_INFO model)
        {
            throw new NotImplementedException();
        }

        public void InitTreeView()
        {
            view.InitData();
        }
    }
}
