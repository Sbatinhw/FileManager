using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using JustFileManager.Modules.DiskList.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.Buttons
{
    class BackSpaceButton : ButtonBase
    {
        private static string name = "...";
        private IOpenFolder window;
        private IFolder folder;
        public BackSpaceButton(IOpenFolder window, IFolder folder): base(name)
        {
            this.window = window;
            this.folder = folder;
        }
        public override void Action()
        {
            DirectoryInfo parent = Directory.GetParent(folder.Path);
            if(parent != null)
            {
                window.OpenFolder(parent.FullName);
            }
            else
            {
                DisksWindow disksWindow = new DisksWindow();
                disksWindow.OpenWindow();
                //currentDirectory = disksWindow.GetDisk;
                window.OpenFolder(disksWindow.GetDisk);
            }
        }
    }
}
