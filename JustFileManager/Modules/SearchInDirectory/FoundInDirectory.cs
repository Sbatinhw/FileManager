using JustFileManager.BaseObjects.Elements;
using JustFileManager.Modules.FileManager.Windows;
using JustFileManager.Modules.SearchInDirectory.Elements;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustFileManager.Modules.SearchInDirectory
{
    static class FoundInDirectory
    {
        public static List<IElement> GetFound(string path, string value, DataDirectory window)
        {
            List<IElement> elements = new List<IElement>();

            AddToList(elements, 0, path, value, window);

            return elements;
        }

        private static bool AddToList(List<IElement> elements, int deep, string path, string value, DataDirectory window)
        {
            string[] dirs = Directory.GetDirectories(path);
            string[] file = Directory.GetFiles(path);
            bool result = false;
            List<IElement> reverseList;

            foreach (var f in file)
            {
                if (new FileInfo(f).Name.ToLower().Contains(value.ToLower()))
                {
                    elements.Add(new FoundFile(deep, f));
                    result = true;
                }
            }
            foreach (var f in dirs)
            {
                if (new DirectoryInfo(f).Name.ToLower().Contains(value.ToLower()))
                {
                    elements.Add(new FoundFolder(deep, f, window));
                    result = true;
                    AddToList(elements, deep + 1, f, value, window);
                }
                else
                {
                    reverseList = new List<IElement>();
                    if (AddToList(reverseList, deep + 1, f, value, window))
                    {

                        reverseList.Add(new FoundFolder(deep, f, window));
                        reverseList.Reverse();
                        elements.AddRange(reverseList);
                        result = true;
                    }
                }
            }


            return result;
        }
    }
}
