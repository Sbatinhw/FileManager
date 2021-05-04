<?xml version="1.0"?>

<doc>

<assembly>

<name>FileManager</name>

</assembly>

<members>

<member name="T:FileManager.FileElement">

<summary>

Класс описывающий папки\файлы и способы взаимодействия

</summary>

</member>

<member name="T:FileManager.FileElement.TypeElement">

<summary>

Тип элемента

</summary>

</member>

<member name="F:FileManager.FileElement.TypeElement.Folder">

<summary>

Папка

</summary>

</member>

<member name="F:FileManager.FileElement.TypeElement.File">

<summary>

Файл

</summary>

</member>

<member name="T:FileManager.FileElement.how\_open">

<summary>

Делегат для открытия элемента в зависимости от типа файла

входящим параметром подаётся текущая директория

если элемент является папкой то открываятся эта папка

</summary>

<param name="change\_line">текщая директория</param>

</member>

<member name="T:FileManager.FileElement.how\_copy">

<summary>

Делегат для копирования элемента

</summary>

<param name="x"> адрес расположения элемента</param>

<param name="y">адрес куда копировать элемент</param>

</member>

<member name="P:FileManager.FileElement.type">

<summary>

Тип элемента

</summary>

</member>

<member name="P:FileManager.FileElement.Way">

<summary>

Адрес элемента

</summary>

</member>

<member name="P:FileManager.FileElement.Name">

<summary>

Имя элемента для отображения

</summary>

</member>

<member name="M:FileManager.FileElement.#ctor(System.String)">

<summary>

Конструктор элемента

</summary>

<param name="path">адрес расположения элемента</param>

</member>

<member name="M:FileManager.FileElement.Info">

<summary>

Создание массива строк с информацией о элементе

</summary>

<returns>Возвращает массив строк</returns>

</member>

<member name="M:FileManager.FileElement.CopyElement(System.String)">

<summary>

Вызов функции для копирования элемента

</summary>

<param name="new\_way">адрес куда копировать элемент</param>

</member>

<member name="M:FileManager.FileElement.CopyFile(System.String,System.String)">

<summary>

Копирование файла

</summary>

<param name="old\_way">текущее расположение файла</param>

<param name="new\_way">адрес куда копировать файл</param>

</member>

<member name="M:FileManager.FileElement.CopyFold(System.String,System.String)">

<summary>

Копирование папки

</summary>

<param name="startdir">полный адрес расположения папки</param>

<param name="newdir">адрес куда копировать</param>

</member>

<member name="M:FileManager.FileElement.RecurseCopy(System.String,System.String)">

<summary>

Проверка на то что папка копируется сама в себя

</summary>

<param name="start">откуда копируется</param>

<param name="end">куда копируется</param>

<returns>true  если папка копируется сама в себя</returns>

</member>

<member name="M:FileManager.FileElement.OpenFolder(System.String@)">

<summary>

Открытие папки

</summary>

<param name="change\_line">изменяет входящую строку на адрес папки</param>

</member>

<member name="M:FileManager.FileElement.OpenFile(System.String@)">

<summary>

Открытие файла

</summary>

<param name="change\_line">в текущей реализации ни на что не влияет</param>

</member>

<member name="M:FileManager.FileElement.DeleteElement">

<summary>

Удаление элемента

</summary>

</member>

<member name="M:FileManager.FileElement.SubMenu">

<summary>

Создаёт список возможных действий с элементом

</summary>

<returns>массив возможных действий</returns>

</member>

<member name="M:FileManager.MainMenu.Menu">

<summary>

Главный метод проекта, из него запускается приложение

</summary>

</member>

<member name="M:FileManager.MainMenu.Operation">

<summary>

Вызов управления кнопками

</summary>

</member>

<member name="M:FileManager.MainMenu.Things">

<summary>

Метод определяет какое дополнительное меню открыть

</summary>

</member>

<member name="M:FileManager.MainMenu.DoCopy">

<summary>

Действия с копированными элементами

</summary>

</member>

<member name="M:FileManager.MainMenu.ClearCopyList">

<summary>

Полная очистка массива с копированными элементами

</summary>

</member>

<member name="M:FileManager.MainMenu.SelectCopyList">

<summary>

Отобразить список копированных элементов

</summary>

</member>

<member name="M:FileManager.MainMenu.PasteCopyList">

<summary>

Вставить копированные элементы в текущую директорию

</summary>

</member>

<member name="M:FileManager.MainMenu.DoThings(System.String,System.Int32)">

<summary>

Вызов дополнительных функций файла\папки

</summary>

<param name="todo">определяет что нужно сделать</param>

<param name="position">номер элемента</param>

</member>

<member name="M:FileManager.MainMenu.AddToCopyList(FileManager.FileElement)">

<summary>

Добавить элемент в массив для копирования

</summary>

<param name="file\_to\_copy"></param>

</member>

<member name="M:FileManager.MainMenu.SubMenu(System.Int32)">

<summary>

Список возможных действий с элементом

</summary>

<param name="position">номер элемента</param>

<returns></returns>

</member>

<member name="M:FileManager.MainMenu.PrintSubMenu(System.String[0:,0:],System.String)">

<summary>

Вывод на консоль списка доступных действий  с элементом

</summary>

<param name="array"></param>

<param name="element\_name"></param>

</member>

<member name="M:FileManager.MainMenu.PrintList">

<summary>

Вывод на консоль списка файлов\папок из текущей директории

</summary>

</member>

<member name="M:FileManager.MainMenu.CreateList">

<summary>

Создание массива файлов\папок для текущей директории

</summary>

<returns>массив элементов</returns>

</member>

<member name="M:FileManager.MainMenu.PrintHead(System.String)">

<summary>

"Шапка" для отображения с каким элементом производится взаимодействие

</summary>

<param name="directory">имя элемента для отображения</param>

</member>

<member name="M:FileManager.MainMenu.PrintInfo(System.String[])">

<summary>

Вывод на консоль массива с информацией о элементе

</summary>

<param name="info">массив строк с информацией</param>

</member>

<member name="T:FileManager.PrintLine">

<summary>

Вывод информации на консоль

</summary>

</member>

<member name="M:FileManager.PrintLine.FullLine">

<summary>

сплошная линия из звёздочек

</summary>

</member>

<member name="M:FileManager.PrintLine.ColorPrint(System.String)">

<summary>

печать текста с выделением, по краям звёзддочки

</summary>

<param name="string\_for\_print">строка для отображения</param>

</member>

<member name="M:FileManager.PrintLine.Print(System.String)">

<summary>

печать текста без выделения цветом

</summary>

<param name="string\_for\_print">текст для отображения</param>

</member>

<member name="T:FileManager.WorkKeys">

<summary>

Класс для взаимодействия клавишами клавиатуры с приложением

</summary>

</member>

<member name="M:FileManager.WorkKeys.Navigation(System.Int32@,System.Int32)">

<summary>

Обработка действий клавиш

</summary>

<param name="select\_position">текущая позиция в меню</param>

<param name="menu\_len">длина отображаемого списка</param>

<returns>какое действие нужно выполнить</returns>

</member>

</members>

</doc>
