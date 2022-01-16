using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.DataElements
{
    abstract class FileBase : DataElementBase, IFile
    {
        private string path;

        public FileBase(string path) : base(path)
        {
            this.path = path;
        }

        protected override string GenerateName(string path)
        {
            return new FileInfo(path).Name;
        }
    }
}
