using JustFileManager.BaseObjects.Elements.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CopyList.Elements.Buttons
{
    class ClearCopyListButton : ButtonBase
    {
        private static string name = "Очистить буфер";
        public ClearCopyListButton() : base(name)
        {

        }
        public override void Action()
        {
            CopyListElements.ClearCopyList();
        }
    }
}
