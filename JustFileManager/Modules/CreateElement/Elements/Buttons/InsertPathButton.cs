using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements;
using JustFileManager.Modules.PathRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CreateElement.Elements.Buttons
{
    class InsertPathButton : IButton
    {
        private static string name = "Директория:";
        private IInsertPath insertPath;
        private string head;
        private IFolder defaultFolder;

        public string Name
        {
            get { return $"{name} {insertPath.Path}"; }
        }

        public InsertPathButton(IFolder defaultFolder, string head, IInsertPath insertPath)
        {
            this.insertPath = insertPath;
            this.head = head;
            this.defaultFolder = defaultFolder;
        }

        public void Action()
        {
            GetPath request = new GetPath(defaultFolder, head);
            if (request.GetValue != null)
            {
                insertPath.InsertPath(request.GetValue.Path);
            }
        }
    }
}
