using JustFileManager.Modules.FileManager.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.SearchInDirectory.Elements
{
    class FoundFile: FileData
    {
        private int deep;
        public override string Name
        {
            get
            {
                return CreateName();
            }
        }
        public FoundFile(int deep, string path) : base(path)
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
