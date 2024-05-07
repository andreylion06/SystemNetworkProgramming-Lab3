﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLab3.Logic
{
    public class DiskInfo
    {
        public void DisplayLogicalDrives()
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Logical Drives:");
            foreach (string drive in drives)
            {
                Console.WriteLine(drive);
            }
        }

        public void DisplayDiskTypes()
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Disk Types:");
            foreach (string drive in drives)
            {
                DriveInfo info = new DriveInfo(drive);
                string typeDescription = GetTypeDescription(info.DriveType);
                Console.WriteLine($"{drive} Type: {info.DriveType} ({typeDescription})");
            }
        }

        private string GetTypeDescription(DriveType type)
        {
            switch (type)
            {
                case DriveType.CDRom:
                    return "An optical disc drive that contains audio or video data";
                case DriveType.Fixed:
                    return "A disk hard drive that is physically attached (fixed) to the device";
                case DriveType.Network:
                    return "A drive that is mapped to a network resource";
                case DriveType.NoRootDirectory:
                    return "A drive that does not have a root directory";
                case DriveType.Ram:
                    return "A RAM disk";
                case DriveType.Removable:
                    return "A disk drive that has removable media, such as a floppy drive, thumb drive, or flash card reader";
                case DriveType.Unknown:
                    return "The type of drive is unknown";
                default:
                    return "Not recognized drive type";
            }
        }

        public void DisplayFileSystemInfo()
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("File System Info:");
            foreach (string drive in drives)
            {
                DriveInfo info = new DriveInfo(drive);
                if (info.IsReady)
                {
                    Console.WriteLine($"{drive} File system: {info.DriveFormat}");
                }
            }
        }

        public void DisplayDiskSpace()
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Disk Space Info:");
            foreach (string drive in drives)
            {
                DriveInfo info = new DriveInfo(drive);
                if (info.IsReady)
                {
                    Console.WriteLine($"{drive} Total size: {info.TotalSize} bytes");
                    Console.WriteLine($"{drive} Available space: {info.AvailableFreeSpace} bytes\n");
                }
            }
        }
    }
}
