using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using JustFileManager.Modules.ConfirmationRequest.Windows;
using JustFileManager.Modules.DiskList.Windows;
using JustFileManager.Modules.FileManager.Elements;
using JustFileManager.Modules.FileManager.Windows;
using JustFileManager.Modules.MainMenu.Windows;
using JustFileManager.Modules.PathRequest;
using JustFileManager.Modules.PathRequest.Elements.DataElements;
using JustFileManager.Modules.PathRequest.Windows;
using JustFileManager.Modules.StringRequest;
using JustFileManager.Modules.StringRequest.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JustFileManager
{
    public class JustFileManager
    {
        private IFolder folder;
        private bool workFlag;
        public JustFileManager(string path)
        {
            if (path != null)
            {
                folder = new FolderData(path, null);
            }
            else
            {
                DisksWindow disksWindow = new DisksWindow();
                disksWindow.OpenWindow();
                folder = disksWindow.GetDisk;
            }
            if (folder != null)
            {
                this.workFlag = true;
            }
        }
        public void Start()
        {
            MainMenuWindow mainMenu = new MainMenuWindow();
            DataDirectory fileManager = new DataDirectory(folder);
            while (workFlag)
            {
                fileManager.OpenWindow();

                folder = fileManager.CurrentDirectory;
                workFlag = fileManager.IsWorking;

                if (workFlag)
                {
                    mainMenu.CurrentDirectory = folder;
                    mainMenu.OpenWindow();
                    workFlag = mainMenu.IsWorking;
                }
                if (!workFlag)
                {
                    ConfirmWindow confirm = new ConfirmWindow("Закрыть приложение?", null);
                    confirm.OpenWindow();
                    if (!confirm.Confirm)
                    {
                        workFlag = true;
                    }
                }
            }

        }
    }
}
