using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.MainMenu.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.MainMenu.Elements.Buttons
{
    class OpenFileManagerButton : ButtonBase
    {
        private static string name = "Файловый менеджер";
        private MainMenuWindow window;
        public OpenFileManagerButton(MainMenuWindow window): base(name)
        {
            this.window = window;
        }
        public override void Action()
        {
            window.PauseWindow();
        }
    }
}
