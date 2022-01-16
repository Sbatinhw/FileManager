using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements;
using JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements.CreateDataFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CreateElement.Elements.Buttons
{
    class ChoiceFolderButton : ButtonBase, IReturnCreateType
    {
        private static string name = "Папка";
        private IFolder defaultFolder;
        private ICreateElement createElement;
        public ICreateElement GetCreateType
        {
            get { return createElement; }
        }
        public ChoiceFolderButton(IFolder defaultFolder) : base(name)
        {
            this.defaultFolder = defaultFolder;
        }
        public override void Action()
        {
            createElement = new CreateFolder(defaultFolder);
        }
    }
}
