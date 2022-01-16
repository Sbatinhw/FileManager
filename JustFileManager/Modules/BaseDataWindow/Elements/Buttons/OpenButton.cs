using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.Buttons
{
    class OpenButton: ButtonBase
    {
        private static string name = "Открыть";
        private IOpenElement openElement;
        public OpenButton(IOpenElement openElement) : base(name)
        {
            this.openElement = openElement;
        }
        public override void Action()
        {
            openElement.OpenElement();
        }
    }
}
