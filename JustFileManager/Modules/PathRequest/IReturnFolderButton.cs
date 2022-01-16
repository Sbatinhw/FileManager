using JustFileManager.BaseObjects.Elements;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.PathRequest
{
    interface IReturnFolderButton: IElement
    {
        IFolder GetFolder { get; }
    }
}
