using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows;
using JustFileManager.BaseObjects.Windows.Gui.KeyBoard;
using JustFileManager.Modules.BaseGetValue.UseElements;
using JustFileManager.Modules.StringRequest.Elements;
using JustFileManager.Modules.StringRequest.Windows.Gui.KeyBoards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.StringRequest.Windows
{
    class StringRequestWindow : WindowBase, IReturnValue<string>
    {
        private string baseValue;
        private IReturnValue<string> value;

        public string GetValue
        {
            get { return value.GetValue; }
        }

        public StringRequestWindow(string head, string subhead, string baseValue)
        {
            base.heading = head;
            base.subHeading = subhead;
            this.baseValue = baseValue;
        }

        protected override List<IElement> GenerateElements()
        {
            List<IElement> elements = new List<IElement>();

            elements.Add(new TextButton(value.GetValue, this));

            return elements;
        }

        protected override IKeyBoard GenerateKeyBoard()
        {
            StringRequestKeyBoard keyBoard = new StringRequestKeyBoard(this, baseValue);
            value = keyBoard;
            return keyBoard;
        }
    }
}
