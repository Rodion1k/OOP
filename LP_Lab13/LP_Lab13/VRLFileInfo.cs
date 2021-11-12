using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace LP_Lab13
{
    static class VRLFileInfo
    {
        public static void GetFullPath(string fileName)
        {
            string catalog = @"D:\GitHub";
            foreach (var file in Directory.EnumerateFiles(catalog, fileName, SearchOption.AllDirectories))
            {
                FileInfo fileInfo = new FileInfo(file);
                Console.WriteLine($"file found, full path - {fileInfo.FullName}");
                Console.WriteLine();
                VRLLog.AddAction("VRLFileInfo", fileInfo.Name, "the full path to the file is defined.\n");
                return;
            }
        }
        public static void FileInfo(string path)
        {
            FileInfo file = new FileInfo(path);
            Console.WriteLine($"file name: {file.Name}");
            Console.WriteLine($"size: {Math.Round(file.Length / Math.Pow(1024, 1))}Kb");
            Console.WriteLine($"extension: {file.Extension}");
            Console.WriteLine();
            VRLLog.AddAction("VRLFileInfo", file.Name, "Basic information about the file is displayed.\n");
        }

        public static void FileTiming(string path)
        {
            FileInfo file = new FileInfo(path);
            Console.WriteLine($"creation time file {file.Name}: {file.CreationTime}");
            Console.WriteLine($"last {file.Name} write time: {file.LastWriteTime}");
            Console.WriteLine();
            VRLLog.AddAction("VRLFileInfo", file.Name, "File timings are defined.\n");
        }
        
        

    }
}