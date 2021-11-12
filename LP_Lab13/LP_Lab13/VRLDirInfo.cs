using System;
using System.IO;
using System.IO.Compression;
namespace LP_Lab13
{
    static class VRLDirInfo
    {
        public static void PrintFileCount(string path)
        {
            Console.WriteLine($"count of files in folder: {path} - {Directory.GetFiles(path).Length}\n");
            VRLLog.AddAction("VRLDirInfo",path,"defined count of files in folder.");
        }
        public static void CreationTime(string path)
        {
            Console.WriteLine($"creation time folder: {path} - {Directory.GetCreationTime(path)}\n");
            VRLLog.AddAction("VRLDirInfo", path, "defined creation time folder.\n");
        }

        public static void SubDirectoryCount(string path)
        {
            Console.WriteLine($"count of subdirectory in directory: {path} - {Directory.GetDirectories(path).Length}\n");
            VRLLog.AddAction("VRLDirInfo", path, "defined count of subdirectory in directory.\n");
        }

        public static void ParentDirectory(string path)
        {
            Console.WriteLine($"parent path of directory: {path} - {Directory.GetParent(path)}\n");
            VRLLog.AddAction("VRLDirInfo", path, "defined parent path of directory.\n");
        }
    }
}