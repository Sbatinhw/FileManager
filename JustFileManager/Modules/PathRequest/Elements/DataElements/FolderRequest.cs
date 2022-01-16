using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.PathRequest.Elements.DataElements
{
    class FolderRequest : FolderBase
    {
        IOpenFolder openFolder;
        public FolderRequest(string path, IOpenFolder openFolder) : base(path)
        {
            this.openFolder = openFolder;
        }
        public override void Action()
        {
            openFolder.OpenFolder(this);
        }
    }
}
