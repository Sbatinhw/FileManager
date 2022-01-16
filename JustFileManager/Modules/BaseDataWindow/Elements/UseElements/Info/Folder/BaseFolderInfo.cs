using JustFileManager.BaseObjects.Elements;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements;
using JustFileManager.Modules.StringRequest.Elements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.BaseDataWindow.Elements.UseElements.Info.Folder
{
    class BaseFolderInfo: IReturnInformation
    {
        private enum Size
        {
            Byte,
            KByte,
            MByte,
            GByte,
            TByte,
            PByte
        }
        private IFolder folder;
        public BaseFolderInfo(IFolder folder)
        {
            this.folder = folder;
        }

        public List<IElement> ReturnInformation()
        {
            List<IElement> elements = new List<IElement>();

            elements.Add(new TextButton($"Имя: {folder.Name}"));
            elements.Add(new TextButton($"Расположение: {folder.Path}"));
            elements.Add(new TextButton($"Тип: Папка"));
            elements.Add(new TextButton($"Размер: {FoldLength()}"));

            return elements;
        }
        private string FoldLength()
        {
            string result;
            long size = CalcSize(folder.Path);
            for (int lvl = 0; true; lvl++)
            {
                if (size > 1024) { size /= 1024; }
                else
                {
                    result = $"{size} {(Size)lvl}";
                    break;
                }
            }

            return result;
        }
        private long CalcSize(string path)
        {
            long size = 0;

            string[] dirs = Directory.GetDirectories(path);
            string[] file = Directory.GetFiles(path);

            foreach (var f in file)
            {
                size += new FileInfo(f).Length;
            }
            foreach (var f in dirs)
            {
                size += CalcSize(f);
            }

            return size;
        }
    }
}
