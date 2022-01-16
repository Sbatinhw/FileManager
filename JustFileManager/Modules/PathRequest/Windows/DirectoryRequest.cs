using JustFileManager.BaseObjects.Elements;
using JustFileManager.Modules.BaseDataWindow.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Window;
using JustFileManager.Modules.DiskList.Windows;
using JustFileManager.Modules.PathRequest.Elements.Buttons;
using JustFileManager.Modules.PathRequest.Elements.DataElements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.PathRequest.Windows
{
    class DirectoryRequest : DataWindow
    {
        private IFolder result;
        public IFolder GetFolder
        {
            get { return result; }
        }
        public DirectoryRequest(string heading, IFolder baseFolder)
        {
            base.heading = heading;
            base.currentDirectory = baseFolder;
        }
        public override void OpenFolder(string folderPath)
        {
            currentDirectory = new FolderRequest(folderPath, null);
        }

        protected override List<IElement> GenerateElements()
        {
            List<IElement> elements;

            string[] dirs;
            string[] file;

            while (true)
            {
                base.subHeading = currentDirectory.Path;
                elements = new List<IElement>();
                elements.Add(new BackSpaceButton(this, currentDirectory));
                elements.Add(new ChooseThisDirectory(this));
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

                    if (currentDirectory == null)
                    {
                        CloseWindow();
                        break;
                    }
                    continue;
                }

                foreach (var f in dirs)
                {
                    elements.Add(new FolderRequest(f, this));
                }

                foreach (var f in file)
                {
                    elements.Add(new FileRequest(f));
                }

                break;
            }

            return elements;
        }

        public void GenerateResult()
        {
            this.result = base.currentDirectory;
            base.CloseWindow();
        }
    }
}
