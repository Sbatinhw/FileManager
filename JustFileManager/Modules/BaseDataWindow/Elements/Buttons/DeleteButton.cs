using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.Buttons
{
    class DeleteButton: ButtonBase
    {
        private static string name = "Удалить";
        private IDeleteElement deleteElement;
        public DeleteButton(IDeleteElement deleteElement) : base(name)
        {
            this.deleteElement = deleteElement;
        }
        public override void Action()
        {
            deleteElement.DeleteElement();
        }
    }
}
