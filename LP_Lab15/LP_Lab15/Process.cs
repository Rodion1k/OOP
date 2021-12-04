using System;
using System.Diagnostics;
using System.IO;
namespace LP_Lab15
{
    public static class MyProcess
    {
        public static void PrintProcessesInfo()
        {
            using (StreamWriter writer = new StreamWriter(@"D:\GitHub\OOP\LP_Lab15V\LP_Lab15V\processes.txt"))
            {
                var allProcesses = Process.GetProcesses();
                foreach (Process process in allProcesses)
                {
                    writer.WriteLine($"id:{process.Id}, name:{process.ProcessName}, priority:{process.BasePriority}");
                }
                
                writer.Close();
                
            }
        }
        
        
    }
}