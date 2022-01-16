using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.PathRequest.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.PathRequest.Elements.Buttons
{
    class ChooseThisDirectory : ButtonBase
    {
        private static string name = "Выбрать эту директорию";
        private DirectoryRequest window;
        public ChooseThisDirectory(DirectoryRequest window): base(name)
        {
            this.window = window;
        }

        public override void Action()
        {
            window.GenerateResult();
        }
    }
}
