using System;
using System.IO;

namespace LP_Lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            //VRLLog.ClearLogFile(); // очистить лог файл от записей 
            VRLDiskInfo.GetMemoryDiskInfo(@"D:\");
            VRLDiskInfo.GetFileSystemInfo(@"D:\");
            VRLDiskInfo.GetDrivesFullInfo();
            VRLFileInfo.GetFullPath("VRLlogfile.txt");
            
            VRLFileInfo.FileInfo(@"D:\filesForPl\in.txt");
            VRLFileInfo.FileTiming(@"D:\filesForPl\in.txt");
            
            //FileManager
            var directory = VRLFileManager.CreateDirectory("VRLInspect", @"D:\GitHub\OOP\LP_Lab13\LP_Lab13");
            var file = VRLFileManager.CreateFile("VRLdirinfo.txt", directory.FullName);
            file.Close();
            VRLFileManager.CreateFile("kek.txt", directory.FullName).Close();
            VRLFileManager.CreateFile("lol.pdf",directory.FullName).Close();
            
            VRLFileManager.WriteInformationToFile(file.Name, @"D:\GitHub\OOP");
            VRLFileManager.CopyFile(file.Name, @"D:\GitHub\OOP\LP_Lab13\LP_Lab13\VRLdirinfo.txt");
            VRLFileManager.DeleteFile(file.Name);
            var directory2 = VRLFileManager.CreateDirectory("VRLFiles", @"D:\GitHub\OOP\LP_Lab13\LP_Lab13");
            VRLFileManager.CopyFiles(directory.FullName, directory2.FullName, ".txt");
            VRLFileManager.ArchiveFolder(directory.FullName, directory.FullName);
            VRLFileManager.DeleteFiles(directory.FullName, ".txt"); // заьестить
            VRLFileManager.ExtractArchive(@$"{directory.FullName}.zip", directory2.FullName);
            
            VRLDirInfo.PrintFileCount(@"D:\GitHub\OOP\LP_Lab13\LP_Lab13");
            VRLDirInfo.CreationTime(@"D:\GitHub\OOP\LP_Lab13\LP_Lab13");
            VRLDirInfo.SubDirectoryCount(@"D:\GitHub\OOP\LP_Lab13");
            VRLDirInfo.ParentDirectory(@"D:\GitHub\OOP\LP_Lab13");
            
            VRLLog.PrintInfoFromLogFile(DateTime.Today);
            VRLLog.PrintInfoFromLogFile("13:00:00","16:00:21");
            VRLLog.GetCountInfoFromLogFile();
            VRLLog.PrintInfoFromLogFile("creation");
            VRLLog.DeleteInfoSkippingHour(17);

        }
    }
}