using JustFileManager.BaseObjects.Elements;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Window;
using JustFileManager.Modules.CopyList.Elements.UseElements.UseFolder;
using JustFileManager.Modules.FileManager.Elements.UseElements.UseFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CopyList.Elements.DataElements
{
    class FolderCopy : FolderBase
    {
        private IUseFolderCopy useFolder;
        private string path;
        public IUseFolderCopy UseFolder
        {
            get { return useFolder; }
        }
        public FolderCopy(string path): base(path)
        {
            this.useFolder = new UseFolderCopy(this);
            this.path = path;
        }
        public override void Action()
        {
            List<IElement> elements = new List<IElement>();
            elements.AddRange(useFolder.GetButtons());
            string head = "Папка";
            string subhead = path;
            new ElementWindow(head, subhead, elements).OpenWindow();
        }
    }
}
