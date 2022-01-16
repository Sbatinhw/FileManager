using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CreateElement.Elements.Buttons
{
    interface IReturnCreateType: IButton
    {
        ICreateElement GetCreateType { get; }
    }
}
