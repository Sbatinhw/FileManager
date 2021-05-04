<?xml version="1.0"?>

<doc>

<assembly>

<name>FileManager</name>

</assembly>

<members>

<member name="T:FileManager.FileElement">

<summary>

FileElement Класс описывающий папки\файлы и способы взаимодействия

</summary>

</member>

<member name="T:FileManager.FileElement.TypeElement">

<summary>

TypeElement Тип элемента

</summary>

</member>

<member name="F:FileManager.FileElement.TypeElement.Folder">

<summary>

TypeElement.Folder Папка

</summary>

</member>

<member name="F:FileManager.FileElement.TypeElement.File">

<summary>

TypeElement.File Файл

</summary>

</member>

<member name="T:FileManager.FileElement.how\_open">

<summary>
FileElement.how_open

Делегат для открытия элемента в зависимости от типа файла

входящим параметром подаётся текущая директория

если элемент является папкой то открываятся эта папка

</summary>

<param name="change\_line">change_line текщая директория</param>

</member>

<member name="T:FileManager.FileElement.how\_copy">

<summary>
how_copy

Делегат для копирования элемента

</summary>

<param name="x">x адрес расположения элемента</param>

<param name="y">y адрес куда копировать элемент</param>

</member>

<member name="P:FileManager.FileElement.type">

<summary>
type

Тип элемента

</summary>

</member>

<member name="P:FileManager.FileElement.Way">

<summary>
Way

Адрес элемента

</summary>

</member>

<member name="P:FileManager.FileElement.Name">

<summary>
Name

Имя элемента для отображения

</summary>

</member>

<member name="M:FileManager.FileElement.#ctor(System.String)">

<summary>
FileElement

Конструктор элемента

</summary>

<param name="path">адрес расположения элемента</param>

</member>

<member name="M:FileManager.FileElement.Info">

<summary>
Info

Создание массива строк с информацией о элементе

</summary>

<returns>Возвращает массив строк</returns>

</member>

<member name="M:FileManager.FileElement.CopyElement(System.String)">

<summary>

CopyElement

Вызов функции для копирования элемента

</summary>

<param name="new\_way">адрес куда копировать элемент</param>

</member>

<member name="M:FileManager.FileElement.CopyFile(System.String,System.String)">

<summary>

CopyFile

Копирование файла

</summary>

<param name="old\_way">текущее расположение файла</param>

<param name="new\_way">адрес куда копировать файл</param>

</member>

<member name="M:FileManager.FileElement.CopyFold(System.String,System.String)">

<summary>

CopyFold

Копирование папки

</summary>

<param name="startdir">полный адрес расположения папки</param>

<param name="newdir">адрес куда копировать</param>

</member>

<member name="M:FileManager.FileElement.RecurseCopy(System.String,System.String)">

<summary>

RecurseCopy

Проверка на то что папка копируется сама в себя

</summary>

<param name="start">откуда копируется</param>

<param name="end">куда копируется</param>

<returns>true  если папка копируется сама в себя</returns>

</member>

<member name="M:FileManager.FileElement.OpenFolder(System.String@)">

<summary>

OpenFolder Открытие папки

</summary>

<param name="change\_line">изменяет входящую строку на адрес папки</param>

</member>

<member name="M:FileManager.FileElement.OpenFile(System.String@)">

<summary>
OpenFile

Открытие файла

</summary>

<param name="change\_line">в текущей реализации ни на что не влияет</param>

</member>

<member name="M:FileManager.FileElement.DeleteElement">

<summary>

DeleteElement

Удаление элемента

</summary>

</member>

<member name="M:FileManager.FileElement.SubMenu">

<summary>

SubMenu

Создаёт список возможных действий с элементом

</summary>

<returns>массив возможных действий</returns>

</member>

<member name="M:FileManager.MainMenu.Menu">

<summary>

MainMenu.Menu

Главный метод проекта, из него запускается приложение

</summary>

</member>

<member name="M:FileManager.MainMenu.Operation">

<summary>

Operation

Вызов управления кнопками

</summary>

</member>

<member name="M:FileManager.MainMenu.Things">

<summary>

Things

Метод определяет какое дополнительное меню открыть

</summary>

</member>

<member name="M:FileManager.MainMenu.DoCopy">

<summary>

DoCopy

Действия с копированными элементами

</summary>

</member>

<member name="M:FileManager.MainMenu.ClearCopyList">

<summary>

ClearCopyList

Полная очистка массива с копированными элементами

</summary>

</member>

<member name="M:FileManager.MainMenu.SelectCopyList">

<summary>

SelectCopyList

Отобразить список копированных элементов

</summary>

</member>

<member name="M:FileManager.MainMenu.PasteCopyList">

<summary>

PasteCopyList

Вставить копированные элементы в текущую директорию

</summary>

</member>

<member name="M:FileManager.MainMenu.DoThings(System.String,System.Int32)">

<summary>

DoThings

Вызов дополнительных функций файла\папки

</summary>

<param name="todo">определяет что нужно сделать</param>

<param name="position">номер элемента</param>

</member>

<member name="M:FileManager.MainMenu.AddToCopyList(FileManager.FileElement)">

<summary>

AddToCopyList

Добавить элемент в массив для копирования

</summary>

<param name="file\_to\_copy"></param>

</member>

<member name="M:FileManager.MainMenu.SubMenu(System.Int32)">

<summary>

SubMenu

Список возможных действий с элементом

</summary>

<param name="position">номер элемента</param>

<returns></returns>

</member>

<member name="M:FileManager.MainMenu.PrintSubMenu(System.String[0:,0:],System.String)">

<summary>

PrintSubMenu

Вывод на консоль списка доступных действий  с элементом

</summary>

<param name="array"></param>

<param name="element\_name"></param>

</member>

<member name="M:FileManager.MainMenu.PrintList">

<summary>

PrintList

Вывод на консоль списка файлов\папок из текущей директории

</summary>

</member>

<member name="M:FileManager.MainMenu.CreateList">

<summary>

CreateList

Создание массива файлов\папок для текущей директории

</summary>

<returns>массив элементов</returns>

</member>

<member name="M:FileManager.MainMenu.PrintHead(System.String)">

<summary>

PrintHead

"Шапка" для отображения с каким элементом производится взаимодействие

</summary>

<param name="directory">имя элемента для отображения</param>

</member>

<member name="M:FileManager.MainMenu.PrintInfo(System.String[])">

<summary>

PrintInfo

Вывод на консоль массива с информацией о элементе

</summary>

<param name="info">массив строк с информацией</param>

</member>

<member name="T:FileManager.PrintLine">

<summary>

PrintLine

Вывод информации на консоль

</summary>

</member>

<member name="M:FileManager.PrintLine.FullLine">

<summary>

FullLine

сплошная линия из звёздочек

</summary>

</member>

<member name="M:FileManager.PrintLine.ColorPrint(System.String)">

<summary>

ColorPrint

печать текста с выделением, по краям звёзддочки

</summary>

<param name="string\_for\_print">строка для отображения</param>

</member>

<member name="M:FileManager.PrintLine.Print(System.String)">

<summary>

Print

печать текста без выделения цветом

</summary>

<param name="string\_for\_print">текст для отображения</param>

</member>

<member name="T:FileManager.WorkKeys">

<summary>

WorkKeys

Класс для взаимодействия клавишами клавиатуры с приложением

</summary>

</member>

<member name="M:FileManager.WorkKeys.Navigation(System.Int32@,System.Int32)">

<summary>

Navigation

Обработка действий клавиш

</summary>

<param name="select\_position">текущая позиция в меню</param>

<param name="menu\_len">длина отображаемого списка</param>

<returns>какое действие нужно выполнить</returns>

</member>

</members>

</doc>
