using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseGetValue;
using JustFileManager.Modules.PathRequest.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.PathRequest
{
    class GetPath : GetValueModule<IFolder>
    {
        private IFolder defaultFolder;
        private string heading;
        public GetPath(IFolder defaultFolder, string heading)
        {
            this.defaultFolder = defaultFolder;
            this.heading = heading;
        }
        protected override IFolder Calculate()
        {
            SourcePathWindow window = new SourcePathWindow(defaultFolder, heading);
            window.OpenWindow();
            return window.FolderRequest;
        }
    }
}
