using System;
using System.IO;
using System.Linq;

namespace LP_Lab13
{
    static class VRLDiskInfo
    {
        public static void GetMemoryDiskInfo(string driveName)
        {
            var allDrives = DriveInfo.GetDrives();
            foreach (var drive in allDrives)
            {
                if (drive.Name == driveName && drive.IsReady)
                {
                    var size = Math.Round(drive.TotalFreeSpace / Math.Pow(1024, 3));
                    Console.WriteLine($"free disk {driveName.First()} space: {size}Gb");
                    Console.WriteLine();
                    VRLLog.AddAction("VRLDiskInfo",driveName,$"disk information about free memory was received: free space - {size}");
                    return;
                }
            }
        }

        public static void GetFileSystemInfo(string driveName)
        {
            var allDrives = DriveInfo.GetDrives();
            foreach (var drive in allDrives)
            {
                if (drive.Name == driveName && drive.IsReady)
                {
                    Console.WriteLine($"disk {drive.Name.First()} has: drive type - {drive.DriveType}, file system - {drive.DriveFormat}");
                    Console.WriteLine();
                    VRLLog.AddAction("VRLDiskInfo",driveName,
                        $"disk File system information  was received: drive type - {drive.DriveType},file system - {drive.DriveFormat} ");
                    return;
                }
            }
        }

        public static void GetDrivesFullInfo()
        {
            var allDrives = DriveInfo.GetDrives();
            foreach (var drive in allDrives)
            {
                if (drive.IsReady)
                {
                    Console.WriteLine($"name: {drive.Name}");
                    Console.WriteLine($"size: {Math.Round(drive.TotalSize / Math.Pow(1024, 3))}Gb");
                    Console.WriteLine($"available space: {Math.Round(drive.AvailableFreeSpace / Math.Pow(1024, 3))}Gb");
                    Console.WriteLine($"volume label: {drive.VolumeLabel}");
                    Console.WriteLine(); 
                    VRLLog.AddAction("VRLDiskInfo",$"{drive.Name.First()}","disk information was received");
                }
            }
        }
        
        
    }
}