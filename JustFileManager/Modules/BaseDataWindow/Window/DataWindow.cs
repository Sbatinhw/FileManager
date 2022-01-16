using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Window
{
    abstract class DataWindow : WindowBase, IOpenFolder
    {
        protected IFolder currentDirectory;

        public virtual void OpenFolder(IFolder folder)
        {
            this.currentDirectory = folder;
            base.currentPosition = 0;
            base.UpdateWindow();
        }

        abstract public void OpenFolder(string folderPath);
    }
}
