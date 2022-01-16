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
    class SelectDirectories : ButtonBase, IReturnFolderButton
    {
        private static string name = "Открыть директории";
        private IFolder result;
        private string heading;
        private IFolder defaultFolder;
        public IFolder GetFolder
        {
            get { return result; }
        }
        public SelectDirectories(string heading, IFolder defaultFolder) : base(name)
        {
            this.heading = heading;
            this.defaultFolder = defaultFolder;
        }

        public override void Action()
        {
            DirectoryRequest request = new DirectoryRequest($"{heading}. Выберите директорию.", defaultFolder);
            request.OpenWindow();
            result = request.GetFolder;
        }
    }
}
