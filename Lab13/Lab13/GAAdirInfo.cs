using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab13
{
    class GAAdirInfo
    {
        public static void FileCount(string path)
        {
            Console.WriteLine($"Кол-во файлов в каталоге {path}: {Directory.GetFiles(path).Length}");
            Console.WriteLine();
            GAAlog.AddSign("GAAdirInfo", path, $"Кол-во файлов в каталоге {path}: {Directory.GetFiles(path).Length}");
        }
        public static void CreationTime(string path)
        {
            Console.WriteLine($"Время создания каталога {path}: {Directory.GetCreationTime(path)}");
            Console.WriteLine();
            GAAlog.AddSign("GAAdirInfo", path, $"Время создания каталога {path}: {Directory.GetCreationTime(path)}");
        }
        public static void SubdirectoriesCount(string path)
        {
            Console.WriteLine($"Количество подкаталогов в каталоге {path}: {Directory.GetDirectories(path).Length}");
            Console.WriteLine();
            GAAlog.AddSign("GAAdirInfo", path, $"Количество подкаталогов в каталоге {path}: {Directory.GetDirectories(path).Length}");

        }
        public static void ParentDirectory(string path)
        {
            Console.WriteLine($"Родительский каталог каталога {path}: {Directory.GetParent(path)}");
            Console.WriteLine();
            GAAlog.AddSign("GAAdirInfo", path, $"Родительский каталог каталога {path}: {Directory.GetParent(path)}");
        }
    }
}
