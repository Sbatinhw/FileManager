using JustFileManager.BaseObjects.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.DataElements
{
    interface IDataElement: IElement
    {
        string Path { get; }
    }
}
