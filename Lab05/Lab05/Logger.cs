using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Lab05.Exceptions;

namespace Lab05
{
    static class Logger
    {
        private static void Report(bool ifFile, string filePath, string log)
        {
            if (ifFile)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(log);
                }
            }
            else
                Console.WriteLine(log);
        }

        public static void Writelog(NewExceptions ex, bool toFile = false, string filePath = @"D:\СЕМ 3\ООТП\Lab05\Lab05\log.txt")
        {
            DateTime time = DateTime.Now;
            string toLog = $"{time} INFO:\n" + $"{ex.Message} \n{ex.ErrorType}";
            Report(toFile, filePath, toLog);
        }
        public class ConsoleLogger
        {
            public static void WriteLog(NewExceptions ex, string _FilePath = @"D:\СЕМ 3\ООТП\Lab05\Lab05\log.txt")
            {
                Logger.Writelog(ex, filePath: _FilePath);
            }
        }
        public class FileLogger
        {
            public static void WriteLog(NewExceptions ex, string _FilePath = @"D:\СЕМ 3\ООТП\Lab05\Lab05\log.txt")
            {
                Logger.Writelog(ex, true, filePath: _FilePath);
            }
        }
    }
}
