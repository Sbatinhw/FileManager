using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements
{
    interface IInsertPath
    {
        string Path { get; }
        void InsertPath(string path);
    }
}
