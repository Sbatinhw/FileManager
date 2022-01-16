using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.Buttons
{
    class AddToCopyListButton: ButtonBase
    {
        private static string name = "Копировать";
        private ICopyElement copyElement;
        public AddToCopyListButton(ICopyElement copyElement) : base(name)
        {
            this.copyElement = copyElement;
        }
        public override void Action()
        {
            copyElement.AddToCopyList();
        }
    }
}
