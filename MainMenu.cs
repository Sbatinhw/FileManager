using System;
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

        /// <summary>
        /// Главный метод приложения.
        /// Через него запускается приложение.
        /// </summary>
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

        /// <summary>
        /// Проверка что директория существует
        /// </summary>
        /// <returns>False если не существует</returns>
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

        /// <summary>
        /// Выводит на консоль содержимое директории.
        /// </summary>
        public void PrintList()
        {
            //Количество выведенных элементов на консоль
            int quant = 0;

            if (select_position == top_limit + quant_element - 1)
            {
                //сдвиг верхней границы
                top_limit++;
            }
            else if (select_position == 0) { top_limit = 0; }

            else if (select_position == top_limit) { top_limit--; }

            PrintLine.FullLine();
            for (int i = top_limit; i < list.Length; i++)
            {
                //остановка вывода на консоль
                if(quant == quant_element) { break; }

                //вывести на консоль с подсветкой
                if (i == select_position) { PrintLine.ColorPrint(list[i].Name); }

                //вывод на консоль без подсветки
                else { PrintLine.Print(list[i].Name); }

                quant++;
            }
            while (quant < quant_element) { PrintLine.Print(""); quant++; }

            PrintLine.FullLine();

        }

        /// <summary>
        /// Создание массива элементов для отображения
        /// </summary>
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

            List<FileElement> listElem = new List<FileElement>();

            listElem.Add(new FileElement(FileElement.TypeElement.backspace));

            for(int i = 0; i < dirs.Length; i++)
            {
                listElem.Add(new FileElement(dirs[i]));
            }

            for (int i = 0; i < file.Length; i++)
            {
                listElem.Add(new FileElement(file[i]));
            }

            if (havecopy) { listElem.Add(new FileElement(FileElement.TypeElement.copylistbutton)); }

            len_menu = listElem.Count - 1;

            list = listElem.ToArray();

            
        }

        /// <summary>
        /// обработка нажатия клавиш в главном меню
        /// </summary>
        public void OperationMenu()
        {
            WorkKeys.Doing act = WorkKeys.Navigation(ref select_position, len_menu);
            switch (act)
            {
                case WorkKeys.Doing.doit: SubMenu(); break;
                case WorkKeys.Doing.exit: workflag = false; break;

            }
        }

        /// <summary>
        /// Дополнительные действия с элементом
        /// </summary>
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

        /// <summary>
        /// Вывод на консоль возможных действий с элементом
        /// </summary>
        /// <param name="array">массив строк отображающих возможные действия</param>
        /// <param name="position">позиция курсора</param>
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

        /// <summary>
        /// Вывод на консоль информации о элементе
        /// </summary>
        /// <param name="info">массив строк</param>
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

        /// <summary>
        /// Заголовок отображающий с каким элементом в данный момент происходит взаимодейстие
        /// </summary>
        /// <param name="directory">Имя элемента</param>
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

        /// <summary>
        /// Очистка массива с копированными элементами
        /// </summary>
        public void ClearCopyList()
        {
            copylist = new FileElement[1];
            havecopy = false;
        }

        /// <summary>
        /// Вывод на консоль содержимого массива с копированными элементами
        /// </summary>
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

        /// <summary>
        /// Вставить содержимое массива в текущую директорию
        /// </summary>
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

        /// <summary>
        /// Добавить элемент в массив для копирования
        /// </summary>
        /// <param name="file_to_copy"></param>
        public void AddToCopyList(FileElement file_to_copy)
        {
            havecopy = true;
            if (copylist[copylist.Length - 1] == null) { copylist[copylist.Length - 1] = file_to_copy; }
            else { Array.Resize(ref copylist, copylist.Length + 1); copylist[copylist.Length - 1] = file_to_copy; }
        }

        //
    }
}
