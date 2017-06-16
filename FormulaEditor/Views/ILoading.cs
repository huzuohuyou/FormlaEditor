using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaEditor.Views
{
    public interface ILoading
    {
        void StopLoading();
        void OnLoading();
        void SendLoadingInfo(string msg);
    }
}
