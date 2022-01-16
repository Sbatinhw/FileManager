using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements.Info.File;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements.Info.Folder;
using JustFileManager.Modules.CopyList.Elements.Buttons;
using JustFileManager.Modules.CopyList.Elements.Buttons.DataButtons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CopyList.Elements.UseElements.UseFolder
{
    class UseFolderCopy : IUseFolderCopy
    {
        private IFolder folder;
        public IDataElement Element
        {
            get
            {
                return folder;
            }
        }

        public UseFolderCopy(IFolder folder)
        {
            this.folder = folder;
        }

        public List<IButton> GetButtons()
        {
            List<IButton> buttons = new List<IButton>();

            buttons.Add(new RemoveFromCopyListButton(this));
            buttons.Add(new SelectInformationButton(this));

            return buttons;
        }

        public void RemoveFromCopyList()
        {
            CopyListElements.RemoveFromCopyList(folder);
        }

        public List<IElement> ReturnInformation()
        {
            return new BaseFolderInfo(folder).ReturnInformation();
        }

        public void CopyElement(string newPath)
        {
            newPath = Path.Combine(newPath, folder.Name);
            if (!RecurseCopy(folder.Path, newPath))
            {
                Directory.CreateDirectory(newPath);
                CopyElement(folder.Path, newPath);
            }
            else { Console.WriteLine("err"); Console.ReadLine(); return; }
        }

        public void ReplaceElement(string newPath)
        {
            if (!RecurseCopy(folder.Path, newPath))
            {
                Directory.Move(folder.Path, Path.Combine(newPath, folder.Name));
            }
            else { Console.WriteLine("err"); Console.ReadLine(); return; }
        }

        private bool RecurseCopy(string start, string end)
        {
            DirectoryInfo in_start = new DirectoryInfo(start);

            if (end.Length < start.Length) { return false; }

            if (start.Equals(end)) { return true; }
            else { return RecurseCopy(in_start.FullName, Directory.GetParent(end).FullName); }
            return false;
        }
        private void CopyElement(string oldPath, string newPath)
        {
            if (RecurseCopy(oldPath, newPath)) { Console.WriteLine("err"); Console.ReadLine(); return; }
            DirectoryInfo dir = new DirectoryInfo(oldPath);

            DirectoryInfo[] fold = dir.GetDirectories();
            FileInfo[] file = dir.GetFiles();

            for (int i = 0; i < file.Length; i++)
            {
                string tempPath = Path.Combine(newPath, file[i].Name);
                File.Copy(file[i].FullName, tempPath);
            }
            for (int i = 0; i < fold.Length; i++)
            {
                string tempPath = Path.Combine(newPath, fold[i].Name);
                Directory.CreateDirectory(tempPath);
                CopyElement(fold[i].FullName, tempPath);

            }
        }
    }
}
