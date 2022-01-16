using JustFileManager.BaseObjects.Windows.Gui.KeyBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.MainMenu.Windows.Gui.Keyboard
{
    class MainMenuKeyboard: IKeyBoard
    {
        protected MainMenuWindow window;
        protected ConsoleKeyInfo key;
        public MainMenuKeyboard(MainMenuWindow window)
        {
            this.window = window;
        }
        public void Navigation()
        {
            key = Console.ReadKey();
            //костыль: при нажатии ESC страница некорректно обновляется
            Console.WriteLine("test");
            Console.Clear();
            //
            Parsing();
        }
        virtual protected void Parsing()
        {
            if (key.Key == ConsoleKey.Escape)
            {
                window.CloseWindow();
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                window.CurrentPositionDown();
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                window.CurrentPositionUp();
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                window.UseElement();
            }
            else if(key.Key == ConsoleKey.Tab)
            {
                window.PauseWindow();
            }
        }
    }
}
