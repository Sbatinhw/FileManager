using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using JustFileManager.Modules.StringRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.Buttons
{
    class RenameButton: ButtonBase
    {
        private static string name = "Переименовать";
        private IDataElement element;
        private IRenameElement renameElement;
        public RenameButton(IDataElement element, IRenameElement renameElement) : base(name)
        {
            this.element = element;
            this.renameElement = renameElement;
        }
        public override void Action()
        {
            StringRequestModule request = new StringRequestModule("Введите новое имя элемента", element.Path, element.Name);
            if (request.GetValue != null)
            {
                renameElement.RenameElement(request.GetValue);
            }
        }
    }
}
