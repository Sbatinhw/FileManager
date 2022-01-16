using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Window
{
    class InformationWindow: WindowBase
    {
        private static string name = "Информация";
        private IReturnInformation information;
        public InformationWindow(IReturnInformation information)
        {
            base.heading = name;
            this.information = information;
        }
        protected override List<IElement> GenerateElements()
        {
            return information.ReturnInformation();
        }
    }
}
