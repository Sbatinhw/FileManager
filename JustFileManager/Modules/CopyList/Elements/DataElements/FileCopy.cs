using JustFileManager.BaseObjects.Elements;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Window;
using JustFileManager.Modules.CopyList.Elements.UseElements.UseFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CopyList.Elements.DataElements
{
    class FileCopy : FileBase
    {
        private IUseFileCopy useFile;
        private string path;
        public IUseFileCopy UseFile
        {
            get { return useFile; }
        }
        public FileCopy(string path): base(path)
        {
            this.useFile = new UseFileCopy(this);
            this.path = path;
        }
        public override void Action()
        {
            List<IElement> elements = new List<IElement>();
            elements.AddRange(useFile.GetButtons());
            string head = "Файл";
            string subhead = path;
            new ElementWindow(head, subhead, elements).OpenWindow();
        }
    }
}
