using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.Buttons;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements.Info.File;
using JustFileManager.Modules.BaseDataWindow.Elements.UseElements.Info.Folder;
using JustFileManager.Modules.CopyList.Elements.Buttons.DataButtons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.CopyList.Elements.UseElements.UseFile
{
    class UseFileCopy : IUseFileCopy
    {
        private IFile file;
        public IDataElement Element
        {
            get
            {
                return file;
            }
        }

        public UseFileCopy(IFile file)
        {
            this.file = file;
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
            CopyListElements.RemoveFromCopyList(file);
        }

        public List<IElement> ReturnInformation()
        {
            return new BaseFileInfo(file).ReturnInformation();
        }

        public void CopyElement(string newPath)
        {
            File.Copy(file.Path, Path.Combine(newPath, file.Name));
        }

        public void ReplaceElement(string newPath)
        {
            File.Move(file.Path, Path.Combine(newPath, file.Name));
        }
    }
}
