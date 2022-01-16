using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements.Info.Folder;
using JustFileManager.Modules.ConfirmationRequest.Windows;
using JustFileManager.Modules.CopyList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.FileManager.Elements.UseElements.UseFolder
{
    class UseFolderData: IUseFolderData
    {
        private IOpenFolder openFolder;
        private IFolder folder;

        public IDataElement element
        {
            get { return folder; }
        }
        public UseFolderData(IFolder folder, IOpenFolder openFolder)
        {
            this.openFolder = openFolder;
            this.folder = folder;
        }
        public void DeleteElement()
        {
            ConfirmWindow confirm = new ConfirmWindow("Удалить папку:", $"{folder.Path}?");
            confirm.OpenWindow();
            if (confirm.Confirm)
            {
                Directory.Delete(folder.Path, true);
            }
        }

        public void OpenElement()
        {
            openFolder.OpenFolder(folder);
        }

        public void RenameElement(string newName)
        {
            Directory.Move(folder.Path, Path.Combine(Directory.GetParent(folder.Path).FullName, newName));
        }

        public void AddToCopyList()
        {
            CopyListElements.AddToCopyList(folder);
        }

        public List<IElement> ReturnInformation()
        {
            return new BaseFolderInfo(folder).ReturnInformation();
        }

        public List<IButton> GetButtons()
        {
            List<IButton> buttons = new List<IButton>();

            buttons.Add(new OpenButton(this));
            buttons.Add(new DeleteButton(this));
            buttons.Add(new RenameButton(this.element, this));
            buttons.Add(new AddToCopyListButton(this));
            buttons.Add(new SelectInformationButton(this));

            return buttons;
        }
    }
}
