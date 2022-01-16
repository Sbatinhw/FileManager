using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.BaseObjects.Windows.Gui.Line
{
    interface IPrintLine
    {
        void FullLine();
        void FullLine(string string_for_print);
        void ColorPrint(string string_for_print);
        void Print(string string_for_print);
    }
}
