using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Window;
using JustFileManager.Modules.FileManager.Elements.UseElements.UseFolder;
using JustFileManager.Modules.FileManager.Windows;
using JustFileManager.Modules.BaseDataWindow.Elements.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JustFileManager.BaseObjects.Elements;

namespace JustFileManager.Modules.FileManager.Elements
{
    class FolderData : FolderBase
    {
        IUseFolderData useFolder;
        public FolderData(string path, DataDirectory window): base(path)
        {
            this.useFolder = new UseFolderData(this, window);
        }
        public override void Action()
        {
            List<IElement> elements = new List<IElement>();
            elements.AddRange( useFolder.GetButtons());
            string head = "Папка";
            string subhead = useFolder.element.Path;
            new ElementWindow(head, subhead, elements).OpenWindow();
        }
    }
}
