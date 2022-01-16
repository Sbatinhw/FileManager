using JustFileManager.Modules.BaseGetValue;
using JustFileManager.Modules.BaseGetValue.UseElements;
using JustFileManager.Modules.StringRequest.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.StringRequest
{
    class StringRequestModule : GetValueModule<string>
    {
        StringRequestWindow window;
        public StringRequestModule(string head, string subhead, string baseValue)
        {
            this.window = new StringRequestWindow(head, subhead, baseValue);
        }
        protected override string Calculate()
        {
            window.OpenWindow();
            return window.GetValue;
        }
    }
}
