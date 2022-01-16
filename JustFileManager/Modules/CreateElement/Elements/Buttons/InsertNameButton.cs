using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements;
using JustFileManager.Modules.StringRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CreateElement.Elements.Buttons
{
    class InsertNameButton : IButton
    {
        private static string name = "Имя:";
        private IInsertName insertName;
        private string head;

        public string Name
        {
            get { return $"{name} {insertName.Name}"; }
        }

        public InsertNameButton(string head, IInsertName insertName)
        {
            this.insertName = insertName;
            this.head = head;
        }

        public void Action()
        {
            insertName.InsertName(new StringRequestModule(head, "Введите имя", insertName.Name).GetValue);
        }
    }
}
