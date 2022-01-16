using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.CopyList.Elements.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CopyList.Elements.Buttons.DataButtons
{
    class RemoveFromCopyListButton : ButtonBase
    {
        private static string name = "Убрать из списка";
        private IRemoveFromCopyList remove;
        public RemoveFromCopyListButton(IRemoveFromCopyList remove): base(name)
        {
            this.remove = remove;
        }
        public override void Action()
        {
            remove.RemoveFromCopyList();
        }
    }
}
