using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.BaseObjects.Windows
{
    interface IWindow
    {
        void OpenWindow();
        void CloseWindow();
        void CurrentPositionUp();
        void CurrentPositionDown();
        void UseElement();
        void UpdateWindow();
    }
}
