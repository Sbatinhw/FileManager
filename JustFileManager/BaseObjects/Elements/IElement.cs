using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.BaseObjects.Elements
{
    interface IElement
    {
        string Name { get; }
        void Action();
    }
}
