using System;

namespace Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            GAAdiskInfo.FreeSpace("C:\\");
            GAAdiskInfo.FileSystem("C:\\");
            GAAdiskInfo.DrivesFullInfo();

            string path = @"C:\Users\Lenovo PC\Desktop\ООТП\Lab13";
            GAAdirInfo.FileCount(path);
            GAAdirInfo.CreationTime(path);
            GAAdirInfo.ParentDirectory(path);
            GAAdirInfo.SubdirectoriesCount(path);

            string path2 = @"C:\Users\Lenovo PC\Desktop\ООТП\Lab13\Lab13\Program.cs";
            GAAfileInfo.FullPath(path2);
            GAAfileInfo.BasicFileInfo(path2);
            GAAfileInfo.CreationTime(path2);

            GAAfileManager.InspectDrive(@"C:\Users\Lenovo PC\Desktop\ООТП");
            GAAfileManager.CopyFiles(@"C:\Users\Lenovo PC\Desktop\ООТП\Lab13\Lab13", ".txt");
            GAAfileManager.ArchiveUnarchive();

            GAAlog.FindByWord("Имя");
            Console.WriteLine("\n");
            GAAlog.FindByDay("18.12.2020");
            Console.WriteLine("\n");
            GAAlog.DeleteFrom("10:");

            Console.WriteLine("Удалить каталоги? 1 - да");
            int key = int.Parse(Console.ReadLine());

            if (key == 1)
            {
                System.IO.Directory.Delete("GAAInspect", true);
                System.IO.Directory.Delete("Unzipped", true);
            }
        }
    }
}
