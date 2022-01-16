using JustFileManager.BaseObjects.Elements.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.UseElements
{
    interface IReturnButtonList
    {
        List<IButton> GetButtons();
    }
}
