using JustFileManager.BaseObjects.Elements;
using JustFileManager.BaseObjects.Windows;
using JustFileManager.BaseObjects.Windows.Gui.KeyBoard;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.MainMenu.Elements.Buttons;
using JustFileManager.Modules.MainMenu.Windows.Gui.Keyboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.MainMenu.Windows
{
    class MainMenuWindow : WindowBase, IMainWindow
    {
        private bool isWorking;
        private IFolder currentDirectory;
        public bool IsWorking
        {
            get { return isWorking; }
        }
        
        public IFolder CurrentDirectory
        {
            get { return currentDirectory; }
            set { currentDirectory = value; }
        }
        public MainMenuWindow()
        {
            
        }
        public override void OpenWindow()
        {
            isWorking = true;
            base.OpenWindow();
        }
        protected override List<IElement> GenerateElements()
        {
            List<IElement> elements = new List<IElement>();

            elements.Add(new OpenFileManagerButton(this));
            elements.Add(new CopyListButton(currentDirectory));
            elements.Add(new CreateDataElementButton(currentDirectory));

            return elements;
        }

        protected override IKeyBoard GenerateKeyBoard()
        {
            return new MainMenuKeyboard(this);
        }
        public override void CloseWindow()
        {
            base.CloseWindow();
            isWorking = false;
        }

        public void PauseWindow()
        {
            base.CloseWindow();
        }
    }
}
