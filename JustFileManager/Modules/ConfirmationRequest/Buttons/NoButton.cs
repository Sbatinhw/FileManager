using JustFileManager.BaseObjects.Elements.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.ConfirmationRequest.Buttons
{
    class NoButton : ButtonBase, IConfirm
    {
        private static string name = "Нет";
        private bool confirm;
        public bool GetConfirm
        {
            get { return confirm; }
        }
        public NoButton() : base(name)
        {
        }

        public override void Action()
        {
            confirm = false;
        }
    }
 }
