using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using JustFileManager.Modules.BaseDataWindow.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.Buttons
{
    class SelectInformationButton : ButtonBase
    {
        private static string name = "Информация";
        private IReturnInformation information;
        public SelectInformationButton(IReturnInformation information) : base(name)
        {
            this.information = information;
        }
        public override void Action()
        {
            new InformationWindow(information).OpenWindow();
        }
    }
}
