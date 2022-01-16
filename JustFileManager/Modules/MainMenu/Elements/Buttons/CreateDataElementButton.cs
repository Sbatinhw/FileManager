using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.CreateElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.MainMenu.Elements.Buttons
{
    class CreateDataElementButton : ButtonBase
    {
        private static string name = "Создать элемент";
        private IFolder defaultFolder;
        public CreateDataElementButton(IFolder defaultFolder) : base(name)
        {
            this.defaultFolder = defaultFolder;
        }
        public override void Action()
        {
            new CreateElementModule(defaultFolder).StartModule();
        }
    }
}
