using JustFileManager.BaseObjects.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.BaseObjects.Windows.Gui.List
{
    interface IPrintListElements
    {
        void Print(int currentPosition, List<IElement> elements);
    }
}
