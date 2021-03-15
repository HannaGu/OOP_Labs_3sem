using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Lab13
{
    class GAAlog
    {
        public static void AddSign(string utility, string path, string message)
        {
            using (StreamWriter sr = new StreamWriter(@"C:\Users\Lenovo PC\Desktop\ООТП\Lab13\Lab13\GAAlog.txt", true))
            {
                sr.WriteLine($"{utility}: {path}");
                sr.WriteLine($"{message}: {DateTime.Now}");
            }
        }
        public static void FindByWord(string word)
        {
            string x;
            StreamReader reader = new StreamReader(@"C:\Users\Lenovo PC\Desktop\ООТП\Lab13\Lab13\GAAlog.txt");
            while (reader.EndOfStream == false)
            {
                x = reader.ReadLine();
                if (x.IndexOf(word) != -1)
                    Console.WriteLine(x);
            }
            reader.Close();
        }
        public static void FindByDay(string day)
        {
            string x;
            StreamReader reader = new StreamReader(@"C:\Users\Lenovo PC\Desktop\ООТП\Lab13\Lab13\GAAlog.txt");
            while (reader.EndOfStream == false)
            { 
                x = reader.ReadLine();
                if (x.IndexOf(day) != -1)
                  for(int i=0; i<4;i++)
                  {
                      Console.WriteLine(x);
                      x = reader.ReadLine();
                  }
            }
            reader.Close();
        }

        public static void DeleteFrom(string time)
        {
           
            string p = @"C:\Users\Lenovo PC\Desktop\ООТП\Lab13\Lab13\GAAlog.txt";            
            File.WriteAllLines(p, File.ReadAllLines(p).Where(v => v.Trim().IndexOf(time) != -1).ToArray());
        }
    }
}
