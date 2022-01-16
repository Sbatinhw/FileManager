using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.BaseObjects.Windows;
using JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CreateElement.Elements.Buttons
{
    class CreateElementButton : ButtonBase
    {
        private static string name = "Создать";
        private IWindow window;
        private ICreateElement createElement;
        public CreateElementButton(IWindow window, ICreateElement createElement): base(name)
        {
            this.window = window;
            this.createElement = createElement;
        }
        public override void Action()
        {
            createElement.Create();
            window.CloseWindow();
        }
    }
}
