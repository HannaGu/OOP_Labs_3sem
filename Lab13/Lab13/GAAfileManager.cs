using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Lab13
{
    class GAAfileManager
    {
         public static void InspectDrive(string driveName)
        {
            DirectoryInfo dir = new DirectoryInfo(driveName);
            FileInfo[] file = dir.GetFiles();
            Directory.CreateDirectory(@"GAAInspect");

            using (StreamWriter sw = new StreamWriter(@"GAAInspect\GAAdirinfo.txt"))
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                    sw.WriteLine(d.Name);

                foreach (FileInfo f in file)
                    sw.WriteLine(f.Name);
            }
            File.Copy(@"GAAInspect\GAAdirinfo.txt", @"GAAInspect\GAAdirinfo_renamed.txt");
            File.Delete(@"GAAInspect\GAAdirinfo.txt");
        }

        public static void CopyFiles(string path, string ext)
        {
            string dirpath = @"C:\Users\Lenovo PC\Desktop\ООТП\Lab13\Lab13\bin\Debug\netcoreapp3.1\GAAFiles";
            Directory.CreateDirectory(dirpath);
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();

            foreach (FileInfo file in files)
            {
                if (file.Extension == ext)
                    file.CopyTo($@"{dirpath}\{file.Name}");
            }
            Directory.Move(@"GAAFiles", @"GAAInspect\GAAFiles");
        }
        public static void ArchiveUnarchive()
        {

            string dirpath = @"GAAInspect\GAAFiles";
            string zippath = @"GAAInspect\GAAFiles.zip";
            string unzippath = @"Unzipped";

            ZipFile.CreateFromDirectory(dirpath, zippath);
            ZipFile.ExtractToDirectory(zippath, unzippath);
        }

    }
}
