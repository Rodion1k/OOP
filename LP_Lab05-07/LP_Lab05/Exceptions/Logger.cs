using System;
using System.IO;

namespace LP_Lab05.Exceptions
{
     class Logger
     {
         public static void WriteLog(Exception ex, bool ConsoleLog,
             string file = @"D:\GitHub\OOP\LP_Lab05\LP_Lab05\Log.txt")
         {
             DateTime time = DateTime.Now;
             if (!ConsoleLog)
             {
                 using StreamWriter streamReader = new StreamWriter(file);
                 streamReader.WriteLine($"Time:{time}");
                 streamReader.Write($"{ex.Message}");
             }
             else
             {
                 Console.WriteLine(ex.Message);
             }
         }

     }
}