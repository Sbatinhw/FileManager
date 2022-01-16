using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Window
{
    class ElementWindow: WindowBase
    {
        private List<IElement> elements;
        public ElementWindow(string head, string subhead, List<IElement> elements)
        {
            base.heading = head;
            base.subHeading = subhead;
            this.elements = elements;
        }

        protected override List<IElement> GenerateElements()
        {
            return elements;
        }
        public override void UseElement()
        {
            base.UseElement();
            base.CloseWindow();
        }
    }
}
