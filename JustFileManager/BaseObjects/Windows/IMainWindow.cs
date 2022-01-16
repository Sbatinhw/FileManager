using JustFileManager.BaseObjects.Windows;
using JustFileManager.Modules.BaseDataWindow.Elements.DataElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.BaseObjects.Windows
{
    interface IMainWindow: IWindow
    {
        bool IsWorking { get; }
        IFolder CurrentDirectory { get; }
        void PauseWindow();
    }
}
