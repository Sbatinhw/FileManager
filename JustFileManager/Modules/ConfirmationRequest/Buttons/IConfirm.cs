using JustFileManager.BaseObjects.Elements.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.ConfirmationRequest.Buttons
{
    interface IConfirm: IButton
    {
        bool GetConfirm { get; }
    }
}
