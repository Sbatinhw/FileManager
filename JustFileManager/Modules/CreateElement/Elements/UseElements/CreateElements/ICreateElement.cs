using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Elements.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements
{
    interface ICreateElement
    {
        string HeadingForWindow { get; }
        bool CreateValidation();
        void Create();
        List<IButton> GetButtonList();
    }
}
