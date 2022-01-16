using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.CopyList.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CopyList
{
    class CopyListModule
    {
        private CopyListMenu copyList;
        public CopyListModule(IFolder currentDirectory)
        {
            copyList = new CopyListMenu(currentDirectory);
        }
        public void OpenModule()
        {
            copyList.OpenWindow();
        }
    }
}
