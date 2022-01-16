using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.BaseObjects.Elements.Buttons
{
    abstract class ButtonBase : IButton
    {
        private string name;
        public string Name
        {
            get { return name; }
        }
        public ButtonBase(string name)
        {
            this.name = name;
        }
        abstract public void Action();
    }
}
