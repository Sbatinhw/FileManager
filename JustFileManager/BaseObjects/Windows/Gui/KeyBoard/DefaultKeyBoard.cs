using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.BaseObjects.Windows.Gui.KeyBoard
{
    class DefaultKeyBoard: IKeyBoard
    {
        protected IWindow window;
        protected ConsoleKeyInfo key;
        public DefaultKeyBoard(IWindow window)
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
        }
    }
}
