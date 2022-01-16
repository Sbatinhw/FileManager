using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows;
using JustFileManager.Modules.ConfirmationRequest.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.ConfirmationRequest.Windows
{
    class ConfirmWindow : WindowBase
    {
        private bool confirm;
        private List<IConfirm> confirmButtons;

        public bool Confirm
        {
            get { return confirm; }
        }
        public ConfirmWindow(string heading, string subHeading)
        {
            base.heading = heading;
            base.subHeading = subHeading;
        }
        protected override List<IElement> GenerateElements()
        {
            List<IElement> elements = new List<IElement>();
            confirmButtons = new List<IConfirm>();

            confirmButtons.Add(new YesButton());
            confirmButtons.Add(new NoButton());

            elements.AddRange(confirmButtons);

            return elements;
        }
        public override void UseElement()
        {
            base.UseElement();
            confirm = confirmButtons[base.currentPosition].GetConfirm;
            base.CloseWindow();
        }
    }
}
