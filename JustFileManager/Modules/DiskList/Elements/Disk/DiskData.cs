using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.DiskList.Elements.Disk
{
    class DiskData: FolderBase, IDisk
    {
        public DiskData(string path) : base(path)
        {
        }
        public override void Action()
        {
            
        }
    }
}
