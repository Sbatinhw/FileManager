using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.DataElements
{
    abstract class FolderBase : DataElementBase, IFolder
    {
        private string path;
        
        public FolderBase(string path): base(path)
        {
            this.path = path;
            
        }

        protected override string GenerateName(string path)
        {
            return new DirectoryInfo(path).Name;
        }
    }
}
