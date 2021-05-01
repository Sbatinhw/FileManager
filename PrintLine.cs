using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    class PrintLine
    {


        static public ConsoleColor text = ConsoleColor.White;
        static public ConsoleColor font = ConsoleColor.Black;
        static public ConsoleColor enter_text = ConsoleColor.Black;
        static public ConsoleColor enter_font = ConsoleColor.White;




        /// <summary>
        /// сплошная линия из звёздочек
        /// </summary>
        public static void FullLine()
        {
            int length_line = Console.WindowWidth - 1;
            StringBuilder line = new StringBuilder();
            for (int i = 0; i < length_line; i++)
            {
                line.Append("*");
            }
            Console.WriteLine(line);
        }

        /// <summary>
        /// печать текста с выделением, по краям звёзддочки
        /// </summary>
        /// <param name="string_for_print">строка для отображения</param>
        public static void ColorPrint(string string_for_print)
        {

            Console.Write("* ");
            Console.BackgroundColor = enter_font;
            Console.ForegroundColor = enter_text;

            StringBuilder line = new StringBuilder();
            line.Append(string_for_print);
            while (true)
            {
                if (line.Length < Console.WindowWidth - 5)
                {
                    line.Append(" ");
                }
                else { break; }
            }
            Console.Write(line);

            Console.BackgroundColor = enter_text;
            Console.ForegroundColor = enter_font;
            Console.WriteLine(" *");


        }

        /// <summary>
        /// печать текста без выделения цветом
        /// </summary>
        /// <param name="string_for_print">текст для отображения</param>
        public static void Print(string string_for_print)
        {
            StringBuilder line = new StringBuilder();
            line.Append("* ");
            line.Append(string_for_print);
            while (true)
            {
                if (line.Length < Console.WindowWidth - 3)
                {
                    line.Append(" ");
                }
                else { break; }
            }
            line.Append(" *");

            Console.WriteLine(line);
        }

        //
    }
}
