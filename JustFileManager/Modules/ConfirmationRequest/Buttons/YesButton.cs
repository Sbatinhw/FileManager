using JustFileManager.BaseObjects.Elements.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.ConfirmationRequest.Buttons
{
    class YesButton : ButtonBase, IConfirm
    {
        private static string name = "Да";
        private bool confirm;
        public bool GetConfirm
        {
            get { return confirm; }
        }
        public YesButton() : base(name)
        {
        }

        public override void Action()
        {
            confirm = true;
        }
    }
}
