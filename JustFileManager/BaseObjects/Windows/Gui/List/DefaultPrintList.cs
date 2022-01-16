using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows.Gui.Line;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.BaseObjects.Windows.Gui.List
{
    class DefaultPrintList: IPrintListElements
    {
        private static int maxElements = 5;
        private int topElement = 0;
        private IPrintLine printLine;

        public DefaultPrintList()
        {
            printLine = new DefaultPrintLine();
        }
        public void Print(int currentPosition, List<IElement> elements)
        {
            int quant = 0;
            
                if (currentPosition == topElement + maxElements - 1)
                {
                    topElement++;
                }
                else if (currentPosition == 0)
                {
                    topElement = 0;
                }
                else if (currentPosition == topElement)
                {
                    topElement--;
                }
                else if (currentPosition > topElement + maxElements - 1)
            {
                topElement = currentPosition - 1;
            }
                else if(currentPosition < topElement)
            {
                topElement = currentPosition;
            }
            printLine.FullLine();
            for (int i = topElement; i < elements.Count; i++)
            {
                if (quant == maxElements) { break; }
                if (i == currentPosition)
                {
                    printLine.ColorPrint(elements[i].Name);
                }
                else
                {
                    printLine.Print(elements[i].Name);
                }
                quant++;
            }
            while (quant < maxElements) { printLine.Print(""); quant++; }
            printLine.FullLine();
            printLine.FullLine($"{currentPosition + 1} {elements.Count} ");
        }
    }
}
