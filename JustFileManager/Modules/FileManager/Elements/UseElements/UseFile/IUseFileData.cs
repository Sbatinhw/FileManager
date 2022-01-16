using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.FileManager.Elements.UseElements.UseFile
{
    interface IUseFileData: ICopyElement, IDeleteElement, IOpenElement, IRenameElement, IReturnInformation, IReturnButtonList
    {
        IDataElement element { get; }
    }
}
