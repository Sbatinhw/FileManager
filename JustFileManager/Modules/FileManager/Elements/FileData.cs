using JustFileManager.BaseObjects.Elements;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Window;
using JustFileManager.Modules.FileManager.Elements.UseElements.UseFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.FileManager.Elements
{
    class FileData : FileBase
    {
        IUseFileData useFile;
        public FileData(string path): base(path)
        {
            this.useFile = new UseFileData(this);
        }
        public override void Action()
        {
            List<IElement> elements = new List<IElement>();
            elements.AddRange(useFile.GetButtons());
            string head = "Файл";
            string subhead = useFile.element.Path;
            new ElementWindow(head, subhead, elements).OpenWindow();
        }
    }
}
