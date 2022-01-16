using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.CopyList.Elements.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CopyList.Windows
{
    class CopyListMenu : WindowBase
    {
        private string name = "Буфер обмена";
        private IFolder currentDirectory;
        public CopyListMenu(IFolder currentDirectory)
        {
            base.heading = name;
            this.currentDirectory = currentDirectory;
        }
        protected override List<IElement> GenerateElements()
        {
            List<IElement> elements = new List<IElement>();

            elements.Add(new OpenCopyListButton());
            elements.Add(new ClearCopyListButton());
            elements.Add(new CopyElementsButton(currentDirectory));
            elements.Add(new ReplcaceElementsButton(currentDirectory));

            return elements;
        }
    }
}
