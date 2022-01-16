using JustFileManager.BaseObjects.Elements;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.CopyList.Elements;
using JustFileManager.Modules.CopyList.Elements.DataElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CopyList
{
    static class CopyListElements
    {
        private static List<FolderCopy> folderCopies = new List<FolderCopy>();
        private static List<FileCopy> fileCopies = new List<FileCopy>();

        public static void AddToCopyList(IFile file)
        {
            FileCopy copy = new FileCopy(file.Path);
            if (!fileCopies.Contains(copy))
            {
                fileCopies.Add(copy);
            }
        }
        public static void AddToCopyList(IFolder folder)
        {
            FolderCopy copy = new FolderCopy(folder.Path);
            if (!folderCopies.Contains(copy))
            {
                folderCopies.Add(copy);
            }
        }

        public static void RemoveFromCopyList(IFolder folder)
        {
            FolderCopy copy = new FolderCopy(folder.Path);
            folderCopies.Remove(copy);
        }
        public static void RemoveFromCopyList(IFile file)
        {
            FileCopy copy = new FileCopy(file.Path);
            fileCopies.Remove(copy);
        }
        public static void ClearCopyList()
        {
            fileCopies.Clear();
            folderCopies.Clear();
        }
        public static List<IElement> GetElements()
        {
            List<IElement> elements = new List<IElement>();
            elements.AddRange(folderCopies);
            elements.AddRange(fileCopies);

            return elements;
        }

        public static void CopyElements(string newPath)
        {
            foreach (var f in folderCopies)
            {
                f.UseFolder.CopyElement(newPath);
                RemoveFromCopyList(f);
            }
            foreach (var f in fileCopies)
            {
                f.UseFile.CopyElement(newPath);
                RemoveFromCopyList(f);
            }
        }
        public static void ReplaceElements(string newPath)
        {
            foreach (var f in folderCopies)
            {
                f.UseFolder.ReplaceElement(newPath);
                RemoveFromCopyList(f);
            }
            foreach (var f in fileCopies)
            {
                f.UseFile.ReplaceElement(newPath);
                RemoveFromCopyList(f);
            }
        }
    }
}
