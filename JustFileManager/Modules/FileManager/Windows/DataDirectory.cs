using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows;
using JustFileManager.BaseObjects.Windows.Gui.KeyBoard;
using JustFileManager.Modules.BaseDataWindow.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Window;
using JustFileManager.Modules.BaseGetValue.UseElements;
using JustFileManager.Modules.DiskList.Elements.Disk;
using JustFileManager.Modules.DiskList.Windows;
using JustFileManager.Modules.FileManager.Elements;
using JustFileManager.Modules.FileManager.Windows.Gui.KeyBoard;
using JustFileManager.Modules.SearchInDirectory;
using JustFileManager.Modules.StringRequest.Elements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.FileManager.Windows
{
    class DataDirectory : DataWindow, IMainWindow
    {
        private bool isWorking;
        private IReturnValue<string> searchValue;
        public bool IsWorking 
        { 
            get 
            {
                return isWorking;
            }  
        }
        public IFolder CurrentDirectory
        {
            get { return currentDirectory; }
        }

        public DataDirectory(IFolder baseValue)
        {
            
            currentDirectory = baseValue;
        }
        public override void OpenWindow()
        {
            isWorking = true;
            base.OpenWindow();
        }
        protected override List<IElement> GenerateElements()
        {
            if(searchValue.GetValue != null)
            {
                heading = "Поиск в директории";
                subHeading = currentDirectory.Path;
                return FoundElements();
            }
            else
            {
                heading = "Директория";
                subHeading = currentDirectory.Path;
                return DataElements();
            }
        }

        private List<IElement> FoundElements()
        {
            List<IElement> elements = new List<IElement>();
            elements.Add(new TextButton($"Поиск: {searchValue.GetValue}"));
            elements.AddRange(FoundInDirectory.GetFound(base.currentDirectory.Path, this.searchValue.GetValue, this));

            return elements;
        }

        private List<IElement> DataElements()
        {
            List<IElement> elements;

            string[] dirs;
            string[] file;

            while (true)
            {
                base.subHeading = base.currentDirectory.Path;
                elements = new List<IElement>();

                elements.Add(new BackSpaceButton(this, currentDirectory));

                try
                {
                    dirs = Directory.GetDirectories(currentDirectory.Path);
                    file = Directory.GetFiles(currentDirectory.Path);
                }

                catch
                {
                    DisksWindow disksWindow = new DisksWindow();
                    disksWindow.OpenWindow();
                    currentDirectory = disksWindow.GetDisk;

                    if(currentDirectory == null)
                    {
                        CloseWindow();
                        break;
                    }

                    continue;
                }

                foreach (var f in dirs)
                {
                    elements.Add(new FolderData(f, this));
                }

                foreach (var f in file)
                {
                    elements.Add(new FileData(f));
                }

                break;
            }

            return elements;
        }

        public override void OpenFolder(string folderPath)
        {
            base.currentDirectory = new FolderData(folderPath, null);
            if (this.searchValue.GetValue != null)
            {
                base.keyBoard = GenerateKeyBoard();
            }
        }
        public override void OpenFolder(IFolder folder)
        {
            base.OpenFolder(folder);
            if (this.searchValue.GetValue != null)
            {
                base.keyBoard = GenerateKeyBoard();
            }
        }
        protected override IKeyBoard GenerateKeyBoard()
        {
            FileManagerKeyBoard keyBoard = new FileManagerKeyBoard(this, null);
            this.searchValue = keyBoard;
            return keyBoard;
        }

        public void PauseWindow()
        {
            base.CloseWindow();
        }
        public override void CloseWindow()
        {
            base.CloseWindow();
            isWorking = false;
        }
    }
}
