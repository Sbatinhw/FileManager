using System;
using JustFileManager;

namespace JustFileManager
{
    class Program
    {
        static void Main(string[] args)
        {
            string basePath;

            try
            {
                basePath = args[0];
            }
            catch
            {
                basePath = null;
            }

            new JustFileManager(basePath).Start();
        }
    }
}
