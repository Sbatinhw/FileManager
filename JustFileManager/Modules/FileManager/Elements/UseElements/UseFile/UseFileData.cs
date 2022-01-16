
using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements.Info.File;
using JustFileManager.Modules.ConfirmationRequest.Windows;
using JustFileManager.Modules.CopyList;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace JustFileManager.Modules.FileManager.Elements.UseElements.UseFile
{
    class UseFileData: IUseFileData
    {
        private IFile file;

        public IDataElement element
        {
            get { return file; }
        }

        public UseFileData(IFile file)
        {
            this.file = file;
        }

        public void DeleteElement()
        {
            ConfirmWindow confirm = new ConfirmWindow("Удалить файл:", $"{file.Path}?");
            confirm.OpenWindow();
            if (confirm.Confirm)
            {
                File.Delete(file.Path);
            }
        }

        public void OpenElement()
        {
            Process process = new Process();
            process.StartInfo.FileName = file.Path;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }

        public void RenameElement(string newName)
        {
            File.Move(file.Path, Path.Combine(Directory.GetParent(file.Path).FullName, newName));
        }

        public void AddToCopyList()
        {
            CopyListElements.AddToCopyList(file);
        }

        public List<IElement> ReturnInformation()
        {
            return new BaseFileInfo(file).ReturnInformation();
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
