using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.PathRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CopyList.Elements.Buttons
{
    class CopyElementsButton : ButtonBase
    {
        private static string name = "Копировать элементы";
        private IFolder currentDirectory;
        public CopyElementsButton(IFolder currentDirectory): base(name)
        {
            this.currentDirectory = currentDirectory;
        }
        public override void Action()
        {
            GetPath request = new GetPath(currentDirectory, "Копирование элементов");
            if(request.GetValue != null)
            {
                CopyListElements.CopyElements(request.GetValue.Path);
            }
        }
    }
}
