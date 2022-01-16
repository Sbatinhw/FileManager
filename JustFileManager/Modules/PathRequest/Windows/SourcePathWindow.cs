using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.PathRequest.Elements.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.PathRequest.Windows
{
    class SourcePathWindow : WindowBase
    {
        private IFolder defaultFolder;
        private IFolder result;
        private List<IReturnFolderButton> folderButtons;
        public IFolder FolderRequest
        {
            get { return result; }
        }
        public SourcePathWindow(IFolder defaultFolder, string heading)
        {
            this.defaultFolder = defaultFolder;
            base.heading = heading;
            base.subHeading = "Источник директории";
        }
        protected override List<IElement> GenerateElements()
        {
            List<IElement> elements = new List<IElement>();
            folderButtons = new List<IReturnFolderButton>();

            folderButtons.Add(new InsertPathButton(heading));

            if(defaultFolder != null)
            {
                folderButtons.Add(new CurrentDirectoryPathButton(defaultFolder));
                folderButtons.Add(new SelectDirectories(heading, defaultFolder));
            }

            elements.AddRange(folderButtons);
            return elements;
        }
        public override void UseElement()
        {
            base.UseElement();
            result = folderButtons[currentPosition].GetFolder;
            if(result != null)
            {
                CloseWindow();
            }
        }
    }
}
