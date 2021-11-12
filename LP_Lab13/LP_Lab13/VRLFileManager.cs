using System;
using System.IO;
using System.IO.Compression;
using System.Linq.Expressions;

namespace LP_Lab13
{
    static class VRLFileManager
    {
        public static DirectoryInfo CreateDirectory(string directoryName, string path)
            =>Directory.CreateDirectory(path+$@"\{directoryName}");
       
        public static FileStream CreateFile(string fileName, string path)
            =>(File.Create(path + $@"\{fileName}"));
        

        public static void WriteInformationToFile(string path,string drive)
        {
            using StreamWriter writer = new StreamWriter(path);
            DirectoryInfo directory = new DirectoryInfo(drive+@"\");
            
            foreach (var dir in directory.GetDirectories())
            {
                writer.WriteLine($"\n***Folder***: {dir.Name}");
                writer.WriteLine("\n&&&files in folder&&&\n--------------------");
                
                foreach (FileInfo file in dir.GetFiles())
                {
                    writer.WriteLine(file.Name);
                }
            }
            writer.Close();
            VRLLog.AddAction("VRLFileManager",path,"written information to file.\n");
        }

        public static void CopyFile(string oldPath, string newPath)
        {
            var file = new FileInfo(oldPath);
            if (!file.Exists)
                throw new Exception("file not found");
            File.Copy(oldPath,newPath,true);
            VRLLog.AddAction("VRLFileManager",oldPath,"copied file.\n");
        }
        public static void CopyFiles(string oldDirPath, string newDirPath, string extension)
        {
            DirectoryInfo directory = new DirectoryInfo(oldDirPath);
            foreach (var file in directory.GetFiles())
            {
                if (file.Extension == extension)
                    File.Copy(file.FullName,newDirPath+$@"\{file.Name}",true);
            }
            VRLLog.AddAction("VRLFileManager",oldDirPath,"copied files.\n");
        }
        public static void DeleteFile(string path)
        {
            File.Delete(path);
            VRLLog.AddAction("VRLFileManager",path,"deleted file.\n");
        }

        public static void DeleteFiles(string path, string extension)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            foreach (var file in directory.GetFiles())
            {
                if (file.Extension == extension)
                    DeleteFile(file.FullName);
            }
            VRLLog.AddAction("VRLFileManager",path,"deleted files.\n");
        }
        
        public static void ArchiveFolder(string pathToFolder, string newPath)
        {
            if (!File.Exists($@"{pathToFolder}.zip"))
            {
                ZipFile.CreateFromDirectory(pathToFolder,$@"{newPath}.zip");
                VRLLog.AddAction("VRLFileManager",pathToFolder,"archived folder.\n");
            }
            
        }

        public static void ExtractArchive(string pathToArch, string newPath)
        {
            ZipFile.ExtractToDirectory(pathToArch, newPath, true);
            VRLLog.AddAction("VRLFileManager",pathToArch,"extract folder.\n");
        }

    }
}