using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements;
using JustFileManager.Modules.CreateElement.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CreateElement
{
    class CreateElementModule
    {
        private ICreateElement createElement;
        private IFolder defaultFolder;
        public CreateElementModule(IFolder defaultFolder)
        {
            this.defaultFolder = defaultFolder;
        }
        public void StartModule()
        {
            ChoiceTypeCreateWindow window = new ChoiceTypeCreateWindow(defaultFolder);
            window.OpenWindow();
            createElement = window.GetCreateElement;

            if(createElement != null)
            {
                new RequestInfoWindow(createElement).OpenWindow();
            }
        }
    }
}
