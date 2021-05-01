using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Главное окно файлового менеджера
/// </summary>
namespace FileManager
{
    class MainMenu
    {
        string start_directory = @"C:\Users\user\Desktop\testfile";
        int top_limit = 0;
        int select_position = 0;
        FileElement[] list;
        FileElement[] copylist = new FileElement[1];
        int len_menu = 0;
        int quant_element = 5;
        bool workflag = true;
        bool havecopy = false;


        /// <summary>
        /// Главный метод проекта, из него запускается приложение
        /// </summary>
        public void Menu()
        {
            while (workflag)
            {
                Console.Clear();
                list = CreateList();
                len_menu = list.Length;
                PrintHead(start_directory);
                PrintList();
                Operation();

            }

        }

        /// <summary>
        /// Вызов управления кнопками
        /// </summary>
        public void Operation()
        {
            WorkKeys.Doing act = WorkKeys.Navigation(ref select_position, len_menu);
            switch (act)
            {
                case WorkKeys.Doing.doit: Things(); break;
                case WorkKeys.Doing.exit: workflag = false; break;

            }
        }

        /// <summary>
        /// Метод определяет какое дополнительное меню открыть
        /// </summary>
        public void Things()
        {
            //вернуться в предыдущий каталог
            if (select_position == 0)
            {
                start_directory = Directory.GetParent(start_directory).FullName;
            }
            //действия с копированными элементами
            else if (select_position == list.Length + 1)
            {
                DoCopy();
            }
            //открыть функции (возможные действия) файла\папки
            else
            {
                int element_num = select_position - 1;
                DoThings(SubMenu(element_num), element_num);
            }
        }

        
        /// <summary>
        /// Действия с копированными элементами
        /// </summary>
        public void DoCopy()
        {
            bool subflag = true;
            string whatdo = "";
            string[,] copymenu =  {
                {"Показать список копированных элементов", "selectcopy" },
                {"Скопировать в текущую директорию","paste" },
                {"Очистить список","clear" }
            };
            while (subflag)
            {
                PrintSubMenu(copymenu, "Буфер");
                WorkKeys.Doing todo = WorkKeys.Navigation(ref select_position, copymenu.GetUpperBound(0));
                switch (todo)
                {
                    case WorkKeys.Doing.exit: subflag = false; break;
                    case WorkKeys.Doing.doit: whatdo = copymenu[select_position, 1]; subflag = false; break;
                }
            }
            switch (whatdo)
            {
                case "selectcopy": SelectCopyList(); break;
                case "paste": PasteCopyList(); break;
                case "clear": ClearCopyList(); break;
            }
        }

        /// <summary>
        /// Полная очистка массива с копированными элементами
        /// </summary>
        public void ClearCopyList()
        {
            copylist = new FileElement[1];
            havecopy = false;
        }

        /// <summary>
        /// Отобразить список копированных элементов
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
        /// Вставить копированные элементы в текущую директорию
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
        /// Вызов дополнительных функций файла\папки
        /// </summary>
        /// <param name="todo">определяет что нужно сделать</param>
        /// <param name="position">номер элемента</param>
        public void DoThings(string todo, int position)
        {
            switch (todo)
            {
                case "open": list[position].OpenElement(ref start_directory); break;
                case "copy": AddToCopyList(list[position]); break;
                case "delete": list[position].DeleteElement(); break;
                case "info": PrintInfo(list[position].Info()); break;
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

        /// <summary>
        /// Список возможных действий с элементом
        /// </summary>
        /// <param name="position">номер элемента</param>
        /// <returns></returns>
        public string SubMenu(int position)
        {
            bool subflag = true;
            string whatdo = "";
            while (subflag)
            {
                string[,] arr = list[position].SubMenu();
                PrintSubMenu(arr, list[position].Name);
                WorkKeys.Doing todo = WorkKeys.Navigation(ref select_position, arr.GetUpperBound(0));
                switch (todo)
                {
                    case WorkKeys.Doing.exit: subflag = false; break;
                    case WorkKeys.Doing.doit: whatdo = arr[select_position, 1]; subflag = false; break;
                }
            }
            return whatdo;
        }

        /// <summary>
        /// Вывод на консоль списка доступных действий  с элементом
        /// </summary>
        /// <param name="array"></param>
        /// <param name="element_name"></param>
        public void PrintSubMenu(string[,] array, string element_name)
        {
            Console.Clear();
            int rows = array.GetUpperBound(0) + 1;
            PrintHead(element_name);
            PrintLine.FullLine();
            for (int i = 0; i < rows; i++)
            {
                if (select_position == i) { PrintLine.ColorPrint(array[i, 0]); }
                else { PrintLine.Print(array[i, 0]); }
            }
            PrintLine.FullLine();

        }

        /// <summary>
        /// Вывод на консоль списка файлов\папок из текущей директории
        /// </summary>
        public void PrintList()
        {
            //количество уже выведеных на консоль элементов
            int quant = 0;

            //если курсор находится внизу напечатаного списка вывести на консоль ещё один элемент
            if (select_position == top_limit + quant_element)
            {
                top_limit++;
            }
            else if (select_position == 0) { top_limit = 0; }
            //если курсор находится вверху напечатаного списка убрать из вывода один элемент
            else if (select_position == top_limit) { top_limit--; }

            //если курсор находится в самом начале списка
            //то вывести на консоль кнопку вернуться в предыдущую директорию
            if (top_limit == 0)
            {
                if (select_position == 0)
                    PrintLine.ColorPrint("...");
                else if (top_limit == 0) { PrintLine.Print("..."); }
            }

            for (int i = top_limit; i < list.Length; i++)
            {
                if (quant == quant_element) { break; }
                if (i == select_position - 1)
                {
                    PrintLine.ColorPrint(list[i].Name);
                }
                else
                {
                    PrintLine.Print(list[i].Name);
                }
                quant++;
            }

            //если в массиве для копированных элементов если файлы\папки
            //отобразить кнопку для вызова меню взаимодействия с этим массивом
            if (havecopy)
            {
                len_menu += 1;
                if (select_position == list.Length + 1)
                {
                    PrintLine.ColorPrint("Скопированные файлы");
                }
                else
                {
                    PrintLine.Print("Скопированные файлы");
                }
            }

            PrintLine.FullLine();


        }



        /// <summary>
        /// Создание массива файлов\папок для текущей директории
        /// </summary>
        /// <returns>массив элементов</returns>
        public FileElement[] CreateList()
        {
            string[] dirs = Directory.GetDirectories(start_directory);
            string[] file = Directory.GetFiles(start_directory);
            int list_len = dirs.Length + file.Length;
            FileElement[] list = new FileElement[list_len];
            for (int i = 0; i < list.Length; i++)
            {
                if (i < dirs.Length)
                {
                    list[i] = new FileElement(dirs[i]);
                }
                else if (i >= dirs.Length)
                {
                    list[i] = new FileElement(file[i - dirs.Length]);
                }
            }
            return list;
        }

        /// <summary>
        /// "Шапка" для отображения с каким элементом производится взаимодействие
        /// </summary>
        /// <param name="directory">имя элемента для отображения</param>
        public void PrintHead(string directory)
        {
            PrintLine.FullLine();
            PrintLine.Print("Элемент: ");
            PrintLine.Print(directory);
            PrintLine.FullLine();
        }

        /// <summary>
        /// Вывод на консоль массива с информацией о элементе
        /// </summary>
        /// <param name="info">массив строк с информацией</param>
        public void PrintInfo(string[] info)
        {
            PrintLine.FullLine();
            for (int i = 0; i < info.Length; i++)
            {
                PrintLine.Print(info[i]);
            }
            PrintLine.FullLine();
            Console.ReadLine();
        }


        //
    }
}
