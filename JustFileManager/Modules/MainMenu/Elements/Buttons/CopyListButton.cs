using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.CopyList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.MainMenu.Elements.Buttons
{
    class CopyListButton : ButtonBase
    {
        private static string name = "Буфер обмена";
        private IFolder currentDirectory;
        public CopyListButton(IFolder currentDirectory) : base(name)
        {
            this.currentDirectory = currentDirectory;
        }
        public override void Action()
        {
            CopyListModule copyList = new CopyListModule(currentDirectory);
            copyList.OpenModule();
        }
    }
}
