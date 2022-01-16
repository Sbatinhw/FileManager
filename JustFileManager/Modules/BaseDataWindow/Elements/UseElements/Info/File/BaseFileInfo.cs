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

namespace JustFileManager.Modules.BaseDataWindow.Elements.UseElements.Info.File
{
    class BaseFileInfo: IReturnInformation
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
        private IFile file;
        public BaseFileInfo(IFile file)
        {
            this.file = file;
        }

        public List<IElement> ReturnInformation()
        {
            List<IElement> elements = new List<IElement>();

            elements.Add(new TextButton($"Имя: {file.Name}"));
            elements.Add(new TextButton($"Расположение: {file.Path}"));
            elements.Add(new TextButton($"Тип: {Path.GetExtension(file.Name)}"));
            elements.Add(new TextButton($"Размер: {FileLength()}"));

            return elements;
        }
        private string FileLength()
        {
            string result;
            long size = new System.IO.FileInfo(file.Path).Length;
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
    }
}
