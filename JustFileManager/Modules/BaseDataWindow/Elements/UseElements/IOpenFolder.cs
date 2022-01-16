using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.UseElements
{
    interface IOpenFolder
    {
        void OpenFolder(IFolder folder);
        void OpenFolder(string folderPath);
    }
}
