using System;

namespace FileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.Menu();

            Console.ReadLine();
        }
    }
}

