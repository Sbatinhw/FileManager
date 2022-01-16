using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.CreateElement.Elements.Buttons;
using JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CreateElement.Windows
{
    class ChoiceTypeCreateWindow : WindowBase
    {
        private ICreateElement createElement;
        private IFolder defaultFolder;
        private List<IReturnCreateType> createTypes;
        public ICreateElement GetCreateElement
        {
            get { return createElement; }
        }
        public ChoiceTypeCreateWindow(IFolder defaultFolder)
        {
            this.defaultFolder = defaultFolder;
            base.heading = "Создание нового элемента";
            base.subHeading = "Выберите тип элемента";
        }
        protected override List<IElement> GenerateElements()
        {
            List<IElement> elements = new List<IElement>();
            createTypes = new List<IReturnCreateType>();

            createTypes.Add(new ChoiceFolderButton(defaultFolder));
            createTypes.Add(new ChoiceFileButton(defaultFolder));

            elements.AddRange(createTypes);
            return elements;
        }
        public override void UseElement()
        {
            base.UseElement();
            createElement = createTypes[currentPosition].GetCreateType;
            base.CloseWindow();
        }
    }
}
