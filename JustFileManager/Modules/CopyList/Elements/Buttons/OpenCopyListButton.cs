using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CopyList.Elements.Buttons
{
    class OpenCopyListButton : ButtonBase
    {
        private static string name = "Открыть список";
        public OpenCopyListButton(): base(name)
        {

        }
        public override void Action()
        {
            new ElementWindow("Буфер обмена", "Элементы в буфере", CopyListElements.GetElements()).OpenWindow();
        }
    }
}
