using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.BaseObjects.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.StringRequest.Elements
{
    class TextButton : ButtonBase
    {
        private IWindow window;
        public TextButton(string value): this(value, null) { }
        public TextButton(string value, IWindow window): base(value)
        {
            this.window = window;
        }
        public override void Action()
        {
            if(window != null)
            {
                window.CloseWindow();
            }
        }
    }
}
