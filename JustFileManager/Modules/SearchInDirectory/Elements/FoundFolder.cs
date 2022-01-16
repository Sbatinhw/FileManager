using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.FileManager.Elements;
using JustFileManager.Modules.FileManager.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.SearchInDirectory.Elements
{
    class FoundFolder : FolderData
    {
        private int deep;
        public override string Name
        {
            get
            {
                return CreateName();
            }
        }
        public FoundFolder(int deep, string path, DataDirectory window) : base(path, window)
        {
            this.deep = deep;
        }
        private string CreateName()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < deep; i++)
            {
                result.Append(" ");
            }
            result.Append(base.name);
            return result.ToString();
        }
    }
}
