using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements;
using JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements.CreateDataFile;
using JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements.CreateDataFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CreateElement.Elements.Buttons
{
    class ChoiceFileButton : ButtonBase, IReturnCreateType
    {
        private static string name = "Файл";
        private IFolder defaultFolder;
        private ICreateElement createElement;
        public ICreateElement GetCreateType
        {
            get { return createElement; }
        }
        public ChoiceFileButton(IFolder defaultFolder) : base(name)
        {
            this.defaultFolder = defaultFolder;
        }
        public override void Action()
        {
            createElement = new CreateFile(defaultFolder);
        }
    }
}
