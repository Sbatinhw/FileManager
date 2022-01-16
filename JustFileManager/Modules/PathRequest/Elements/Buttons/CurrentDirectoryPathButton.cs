using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseGetValue.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.PathRequest.Elements.Buttons
{
    class CurrentDirectoryPathButton : ButtonBase, IReturnFolderButton
    {
        private static string name = "Выбрать эту директорию";
        private IFolder defaultFolder;
        public IFolder GetFolder
        {
            get { return defaultFolder; }
        }

        public CurrentDirectoryPathButton(IFolder defaultFolder) : base(name)
        {
            this.defaultFolder = defaultFolder;
        }

        public override void Action()
        {
        }

    }
}
