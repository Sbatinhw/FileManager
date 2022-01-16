using JustFileManager.BaseObjects.Windows;
using JustFileManager.BaseObjects.Windows.Gui.KeyBoard;
using JustFileManager.Modules.BaseGetValue.UseElements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.StringRequest.Windows.Gui.KeyBoards
{
    class StringRequestKeyBoard : IReturnValue<string>, IKeyBoard
    {
        private StringBuilder value;
        protected ConsoleKeyInfo key;
        private string baseValue;
        public string GetValue
        {
            get
            {
                if (value == null)
                {
                    return null;
                }
                else if(value.Length == 0)
                {
                    return null;
                }
                else
                {
                    return value.ToString();
                }
            }
        }
        IWindow window;
        public StringRequestKeyBoard(StringRequestWindow window, string baseValue)
        {
            this.window = window;
            this.value = new StringBuilder();
            this.baseValue = baseValue;
            if(baseValue != null)
            {
                value.Append(baseValue);
            }
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
        protected void Parsing()
        {
            if (key.Key == ConsoleKey.Escape)
            {
                value = new StringBuilder(baseValue);
                window.CloseWindow();
            }
            else if (key.Key == ConsoleKey.Backspace)
            {
                RemoveLastSymb();
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                window.UseElement();
            }
            else if (CheckSymb(key.KeyChar))
            {
                value.Append(key.KeyChar);
            }

            window.UpdateWindow();
        }
        private bool CheckSymb(char sym)
        {
            if
                (
                char.IsLetterOrDigit(sym) ||
                char.IsPunctuation(sym) ||
                char.IsSeparator(sym) ||
                char.IsSymbol(sym)
                ) { return true; }
            return false;
        }

        private void RemoveLastSymb()
        {
            try
            {
                value.Remove(value.Length - 1, 1);
            }
            catch
            {

            }
        }
    }
}
