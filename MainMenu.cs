﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileManager
{
    class MainMenu
    {
        string start_directory = Properties.Settings.Default.start_directory;
        int select_position = 0;
        int top_limit = 0;
        FileElement[] list;
        FileElement[] copylist = new FileElement[1];
        int len_menu = 0;
        int quant_element = Properties.Settings.Default.page_len;
        bool workflag = true;
        bool PrintHelp = Properties.Settings.Default.help;
        bool havecopy = false;

        public void Menu()
        {
            while (workflag)
            {
                Console.Clear();
                if (CheckDir()) { CreateList(); }
                PrintHead(start_directory);
                PrintList();
                if (PrintHelp) { PrintHelpMenu(); }
                OperationMenu();
                SaveSettings();
            }
            Console.Clear();
            Console.WriteLine("Работа завершена. Нажмите ENTER для выхода.");
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.start_directory = start_directory;
            Properties.Settings.Default.page_len = quant_element;
            Properties.Settings.Default.help = PrintHelp;
            Properties.Settings.Default.Save();
        }

        public bool CheckDir()
        {
            if (Directory.Exists(start_directory)) { return true; }

            DriveInfo[] alldrive = DriveInfo.GetDrives();
            list = new FileElement[alldrive.Length];

            for (int i = 0; i < list.Length; i++)
            {
                list[i] = new FileElement(FileElement.TypeElement.drive, alldrive[i].Name);
            }
            len_menu = list.Length - 1;
            start_directory = $"Укажите диск";

            return false;

        }

        public void PrintList()
        {
            int quant = 0;

            if (select_position == top_limit + quant_element - 1)
            {
                top_limit++;
            }
            else if (select_position == 0) { top_limit = 0; }

            else if (select_position == top_limit) { top_limit--; }

            PrintLine.FullLine();
            for (int i = top_limit; i < list.Length; i++)
            {
                if(quant == quant_element) { break; }
                if (i == select_position) { PrintLine.ColorPrint(list[i].Name); }
                else { PrintLine.Print(list[i].Name); }
                quant++;
            }
            while (quant < quant_element) { PrintLine.Print(""); quant++; }

            PrintLine.FullLine();

        }

        public void CreateList()
        {
            string[] dirs;
            string[] file;
            try
            {
                dirs = Directory.GetDirectories(start_directory);
                file = Directory.GetFiles(start_directory);
            }

            catch
            {
                PrintHead(start_directory);
                PrintLine.FullLine();
                PrintLine.Print("ошибка доступа");
                start_directory = Directory.GetParent(start_directory)?.FullName;
                PrintLine.FullLine();
                Console.ReadLine();
                Console.Clear();
                return;
            }

            int first_button = 1;
            int last_button = 0;

            if (havecopy)
            {
                last_button += 1;
            }

            int list_len = dirs.Length + file.Length + first_button + last_button;

            list = new FileElement[list_len];

            list[0] = new FileElement(FileElement.TypeElement.backspace);

            if (havecopy)
            {
                list[list.Length - 1] = new FileElement(FileElement.TypeElement.copylistbutton);
            }

            for (int i = 1; i < list.Length - last_button; i++)
            {
                if (i - first_button < dirs.Length)
                {
                    list[i] = new FileElement(dirs[i - first_button]);
                }
                else if (i  >= dirs.Length + first_button)
                {
                    list[i] = new FileElement(file[i - dirs.Length - first_button]);
                }
            }

            len_menu = list.Length - 1;
        }

        public void OperationMenu()
        {
            WorkKeys.Doing act = WorkKeys.Navigation(ref select_position, len_menu);
            switch (act)
            {
                case WorkKeys.Doing.doit: SubMenu(); break;
                case WorkKeys.Doing.exit: workflag = false; break;

            }
        }

        public void SubMenu()
        {
            int position = 0;
            string[,] subarr = list[select_position].SubMenu();
            int rows = subarr.GetUpperBound(0);
            bool subworkflag = true;
            string todo = "";

            while (subworkflag)
            {
                PrintSubMenu(subarr, position);
                WorkKeys.Doing act = WorkKeys.Navigation(ref position, rows);
                switch (act)
                {
                    case WorkKeys.Doing.exit: subworkflag = false; break;
                    case WorkKeys.Doing.doit: todo = subarr[position, 1]; subworkflag = false; break;
                }
                    
            }

            switch (todo)
            {
                case "open": list[select_position].OpenElement(ref start_directory); break;
                case "copy": AddToCopyList(list[select_position]); break;
                case "delete": list[select_position].DeleteElement(); break;
                case "info": PrintInfo(list[select_position].Info());  break;
                case "backfold": list[select_position].OpenParentDir(ref start_directory); break;
                case "selectcopy": SelectCopyList(); break;
                case "paste": PasteCopyList(); break;
                case "clear": ClearCopyList(); break;
            }

        }

        public void PrintSubMenu(string[,] array, int position)
        {
            Console.Clear();
            PrintHead(list[select_position].Name);
            PrintLine.FullLine();
            int rows = array.GetUpperBound(0) + 1;
            for (int i = 0; i < rows; i++)
            {
                if(i == position) { PrintLine.ColorPrint(array[i, 0]); }
                else { PrintLine.Print(array[i, 0]); }
            }
            PrintLine.FullLine();
            if (PrintHelp) { PrintHelpMenu(); }
        }

        public void PrintInfo(string[] info)
        {
            Console.Clear();
            PrintLine.FullLine();
            for (int i = 0; i < info.Length; i++)
            {
                PrintLine.Print(info[i]);
            }
            PrintLine.FullLine();
            Console.ReadLine();
        }

        public void PrintHead(string directory)
        {
            PrintLine.FullLine();
            PrintLine.Print("Элемент: ");
            PrintLine.Print(directory);
            PrintLine.FullLine();
        }

        public void PrintHelpMenu()
        {
            PrintLine.FullLine();
            PrintLine.Print("Стрелочки вверх и вниз для листания.");
            PrintLine.Print("Esc для выхода.");
            PrintLine.Print("Enter для выбора.");
            PrintLine.FullLine();
        }

        public void ClearCopyList()
        {
            copylist = new FileElement[1];
            havecopy = false;
        }

        public void SelectCopyList()
        {
            int z = 0;
            PrintLine.FullLine();
            for (int i = 0; i < copylist.Length; i++)
            {
                if (copylist[i] != null)
                {
                    z++;
                    PrintLine.Print(copylist[i].Name);
                }
            }
            if (z == 0) { PrintLine.Print("Список пуст"); }
            PrintLine.FullLine();
            Console.ReadLine();
        }

        public void PasteCopyList()
        {
            for (int i = 0; i < copylist.Length; i++)
            {
                if (copylist[i] != null)
                {
                    copylist[i].CopyElement(start_directory);
                }
            }
        }

        public void AddToCopyList(FileElement file_to_copy)
        {
            havecopy = true;
            if (copylist[copylist.Length - 1] == null) { copylist[copylist.Length - 1] = file_to_copy; }
            else { Array.Resize(ref copylist, copylist.Length + 1); copylist[copylist.Length - 1] = file_to_copy; }
        }

        //
    }
}
