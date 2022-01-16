using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.BaseObjects.Windows.Gui.Line
{
    class DefaultPrintLine : IPrintLine
    {
        private ConsoleColor text = ConsoleColor.White;
        private ConsoleColor font = ConsoleColor.Black;
        private ConsoleColor enter_text = ConsoleColor.Black;
        private ConsoleColor enter_font = ConsoleColor.White;

        static private string indent = "*";
        static private string leftIndent = $"{indent} ";
        static private string rightIndent = $" {indent}";
        public void ColorPrint(string string_for_print)
        {
            Console.Write(leftIndent);
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
            Console.WriteLine(rightIndent);
        }

        public void FullLine()
        {
            int length_line = Console.WindowWidth - 1;
            StringBuilder line = new StringBuilder();
            for (int i = 0; i < length_line; i++)
            {
                line.Append(indent);
            }
            Console.WriteLine(line);
        }

        public void FullLine(string string_for_print)
        {
            int length_line = Console.WindowWidth - 1;
            StringBuilder line = new StringBuilder();
            line.Append(leftIndent);
            line.Append(string_for_print);
            for (int i = line.Length; i < length_line; i++)
            {
                line.Append(indent);
            }
            Console.WriteLine(line);
        }

        public void Print(string string_for_print)
        {
            StringBuilder line = new StringBuilder();
            line.Append(leftIndent);
            line.Append(string_for_print);
            while (true)
            {
                if (line.Length < Console.WindowWidth - 3)
                {
                    line.Append(" ");
                }
                else { break; }
            }
            line.Append(rightIndent);

            Console.WriteLine(line);
        }
    }
}
