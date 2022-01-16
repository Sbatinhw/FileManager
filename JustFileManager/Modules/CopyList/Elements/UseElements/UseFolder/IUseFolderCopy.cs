using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CopyList.Elements.UseElements.UseFolder
{
    interface IUseFolderCopy: IRemoveFromCopyList, IReturnInformation, IReturnButtonList, ICopyElement, IReplaceElement
    {
        IDataElement Element { get; }
    }
}
