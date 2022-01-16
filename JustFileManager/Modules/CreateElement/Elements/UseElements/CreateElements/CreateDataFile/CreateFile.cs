using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.CreateElement.Elements.Buttons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CreateElement.Elements.UseElements.CreateElements.CreateDataFile
{
    class CreateFile: ICreateElement, IInsertName, IInsertPath
    {
        private string path;
        private string name;
        private IFolder defaultFolder;
        private List<IButton> buttons;
        private string heading = "Создание файла";
        public string Name
        {
            get { return name; }
        }

        public string Path
        {
            get { return path; }
        }

        public string HeadingForWindow
        {
            get { return heading; }
        }

        public CreateFile(IFolder defaultFolder)
        {
            this.defaultFolder = defaultFolder;
            GenerateButtonsList();
        }

        public void Create()
        {
            if (CreateValidation())
            {
                File.Create(System.IO.Path.Combine(path, name));
            }
        }

        public bool CreateValidation()
        {
            if (!Directory.Exists(path))
            {
                return false;
            }
            if (name == null)
            {
                return false;
            }
            if (File.Exists(System.IO.Path.Combine(path, name)))
            {
                return false;
            }

            return true;
        }

        public List<IButton> GetButtonList()
        {
            return buttons;
        }

        private List<IButton> GenerateButtonsList()
        {
            buttons = new List<IButton>();

            buttons.Add(new InsertNameButton(heading, this));
            buttons.Add(new InsertPathButton(defaultFolder, heading, this));

            return buttons;
        }

        public void InsertName(string name)
        {
            this.name = name;
        }

        public void InsertPath(string path)
        {
            this.path = path;
        }
    }
}
