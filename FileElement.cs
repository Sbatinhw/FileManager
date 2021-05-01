using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace FileManager
{
    /// <summary>
    /// Класс описывающий папки\файлы и способы взаимодействия
    /// </summary>
    class FileElement
    {
        /// <summary>
        /// Тип элемента
        /// </summary>
        public enum TypeElement
        {
            /// <summary>
            /// Папка
            /// </summary>
            Folder,
            /// <summary>
            /// Файл
            /// </summary>
            File
        }

        /// <summary>
        /// Делегат для открытия элемента в зависимости от типа файла
        /// входящим параметром подаётся текущая директория
        /// если элемент является папкой то открываятся эта папка
        /// </summary>
        /// <param name="change_line">текщая директория</param>
        delegate void how_open(ref string change_line);

        /// <summary>
        /// Делегат для копирования элемента
        /// </summary>
        /// <param name="x"> адрес расположения элемента</param>
        /// <param name="y">адрес куда копировать элемент</param>
        delegate void how_copy(string x, string y);

        how_open open_element;
        how_copy copy_element;

        /// <summary>
        /// Тип элемента
        /// </summary>
        public TypeElement type { get; }

        /// <summary>
        /// Адрес элемента
        /// </summary>
        public string Way { get; }
        /// <summary>
        /// Имя элемента для отображения
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Конструктор элемента
        /// </summary>
        /// <param name="path">адрес расположения элемента</param>
        public FileElement(string path)
        {
            Way = path;
            if (Directory.Exists(Way))
            {
                type = TypeElement.Folder;
                DirectoryInfo dirInfo = new DirectoryInfo(Way);
                Name = dirInfo.Name;
            }
            else if (File.Exists(Way))
            {
                type = TypeElement.File;
                FileInfo filInfo = new FileInfo(Way);
                Name = filInfo.Name;
            }
            if (type == TypeElement.File) { open_element = OpenFile; copy_element = CopyFile; }
            else { open_element = OpenFolder; copy_element = CopyFold; }


        }

        /// <summary>
        /// Создание массива строк с информацией о элементе
        /// </summary>
        /// <returns>Возвращает массив строк</returns>
        public string[] Info()
        {
            DirectoryInfo dir = new DirectoryInfo(Way);
            string[] array =
            {
                $"Имя: {dir.Name}",
                $"Расположение: {dir.FullName}",
                $"Создан: {dir.CreationTime}"
            };
            return array;
        }

        /// <summary>
        /// Вызов функции для копирования элемента
        /// </summary>
        /// <param name="new_way">адрес куда копировать элемент</param>
        public void CopyElement(string new_way)
        {
            if (type == TypeElement.Folder)
            {
                DirectoryInfo dir = new DirectoryInfo(Way);
                new_way = Path.Combine(new_way, dir.Name);
                Directory.CreateDirectory(new_way);
            }
            copy_element(Way, new_way);
        }

        /// <summary>
        /// Копирование файла
        /// </summary>
        /// <param name="old_way">текущее расположение файла</param>
        /// <param name="new_way">адрес куда копировать файл</param>
        public void CopyFile(string old_way, string new_way)
        {
            { File.Copy(old_way, Path.Combine(new_way, Name)); }
        }

        /// <summary>
        /// Копирование папки
        /// </summary>
        /// <param name="startdir">полный адрес расположения папки</param>
        /// <param name="newdir">адрес куда копировать</param>
        public static void CopyFold(string startdir, string newdir)
        {
            if (RecurseCopy(startdir, newdir)) { Console.WriteLine("err"); Console.ReadLine(); return; }
            DirectoryInfo dir = new DirectoryInfo(startdir);



            DirectoryInfo[] fold = dir.GetDirectories();
            FileInfo[] file = dir.GetFiles();


            for (int i = 0; i < file.Length; i++)
            {
                string tempPath = Path.Combine(newdir, file[i].Name);
                File.Copy(file[i].FullName, tempPath);
            }
            for (int i = 0; i < fold.Length; i++)
            {
                string tempPath = Path.Combine(newdir, fold[i].Name);
                Directory.CreateDirectory(tempPath);
                CopyFold(fold[i].FullName, tempPath);

            }
        }

        /// <summary>
        /// Проверка на то что папка копируется сама в себя
        /// </summary>
        /// <param name="start">откуда копируется</param>
        /// <param name="end">куда копируется</param>
        /// <returns>true  если папка копируется сама в себя</returns>
        public static bool RecurseCopy(string start, string end)
        {
            DirectoryInfo in_start = new DirectoryInfo(start);

            if (end.Length < start.Length) { return false; }

            if (start == end) { return true; }
            else { return RecurseCopy(in_start.FullName, Directory.GetParent(end).FullName); }
            return false;
        }

        public void OpenElement(ref string change_line)
        {
            open_element(ref change_line);

        }

        /// <summary>
        /// Открытие папки
        /// </summary>
        /// <param name="change_line">изменяет входящую строку на адрес папки</param>
        public void OpenFolder(ref string change_line)
        {
            change_line = Way;
        }

        /// <summary>
        /// Открытие файла
        /// </summary>
        /// <param name="change_line">в текущей реализации ни на что не влияет</param>
        public void OpenFile(ref string change_line)
        {
            Process process = new Process();
            process.StartInfo.FileName = Way;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }

        /// <summary>
        /// Удаление элемента
        /// </summary>
        public void DeleteElement()
        {
            if (File.Exists(Way))
            {
                File.Delete(Way);
            }
            else if (Directory.Exists(Way))
            {
                Directory.Delete(Way, true);
            }
        }

        /// <summary>
        /// Создаёт список возможных действий с элементом
        /// </summary>
        /// <returns>массив возможных действий</returns>
        public string[,] SubMenu()
        {
            string[,] menu =
            {
                { "Открыть", "open" },
                {"Копировать", "copy" },
                {"Удалить", "delete" },
                {"Информация", "info" }
            };
            return menu;
        }

        //
    }
}


