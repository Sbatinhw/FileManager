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
    class ReplcaceElementsButton : ButtonBase
    {
        private static string name = "Переместить элементы";
        private IFolder currentDirectory;
        public ReplcaceElementsButton(IFolder currentDirectory) : base(name)
        {
            this.currentDirectory = currentDirectory;
        }
        public override void Action()
        {
            GetPath request = new GetPath(currentDirectory, "Перемещение элементов");
            if (request.GetValue != null)
            {
                CopyListElements.ReplaceElements(request.GetValue.Path);
            }
        }
    }
}
