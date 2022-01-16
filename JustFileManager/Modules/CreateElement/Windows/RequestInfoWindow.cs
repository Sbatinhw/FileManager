using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows;
using JustFileManager.Modules.CreateElement.Elements.Buttons;
using JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CreateElement.Windows
{
    class RequestInfoWindow : WindowBase
    {
        private ICreateElement createElement;
        public RequestInfoWindow(ICreateElement createElement)
        {
            this.createElement = createElement;
            base.subHeading = "Заполните поля";
            base.heading = createElement.HeadingForWindow;
        }
        protected override List<IElement> GenerateElements()
        {
            List<IElement> elements = new List<IElement>();

            elements.AddRange(createElement.GetButtonList());
            if (createElement.CreateValidation())
            {
                elements.Add(new CreateElementButton(this, createElement));
            }

            return elements;
        }
    }
}
