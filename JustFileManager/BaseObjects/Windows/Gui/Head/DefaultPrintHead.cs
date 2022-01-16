using JustFileManager.BaseObjects.Windows.Gui.Line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.BaseObjects.Windows.Gui.Head
{
    class DefaultPrintHead : IPrintHead
    {
        private IPrintLine printLine;

        public DefaultPrintHead()
        {
            printLine = new DefaultPrintLine();
        }
        public void Print(string head, string subHead)
        {
            printLine.FullLine();
            printLine.Print(head);
            printLine.Print(subHead);
            printLine.FullLine();
        }
    }
}
