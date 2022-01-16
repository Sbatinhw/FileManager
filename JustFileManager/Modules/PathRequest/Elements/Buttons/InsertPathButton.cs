using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.PathRequest.Elements.DataElements;
using JustFileManager.Modules.StringRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.PathRequest.Elements.Buttons
{
    class InsertPathButton : ButtonBase, IReturnFolderButton
    {
        private static string name = "Введите адрес директории";
        private IFolder result;
        private string heading;
        public IFolder GetFolder
        {
            get { return result; }
        }

        public InsertPathButton(string heading) : base(name)
        {
            this.heading = heading;
        }


        public override void Action()
        {
            StringRequestModule request = new StringRequestModule(heading, name, null);
            if(request.GetValue != null)
            {
                result = new FolderRequest(request.GetValue, null);
            }
        }
    }
}
