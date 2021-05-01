using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    /// <summary>
    /// Класс для взаимодействия клавишами клавиатуры с приложением
    /// </summary>
    class WorkKeys
    {
        
        public enum Doing
        {
            doit,
            nothing,
            exit,
            paste
        }

        /// <summary>
        /// Обработка действий клавиш
        /// </summary>
        /// <param name="select_position">текущая позиция в меню</param>
        /// <param name="menu_len">длина отображаемого списка</param>
        /// <returns>какое действие нужно выполнить</returns>
        public static Doing Navigation(ref int select_position, int menu_len)
        {
            ConsoleKeyInfo key;
            key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                return Doing.exit;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                select_position++;
                if (select_position > menu_len) { select_position = 0; }
                return Doing.nothing;
            }
            else if (key.Key == ConsoleKey.UpArrow)
            {
                select_position--;
                if (select_position < 0) { select_position = 0; }
                return Doing.nothing;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                return Doing.doit;
            }





            return Doing.nothing;
        }


        //
    }
}
