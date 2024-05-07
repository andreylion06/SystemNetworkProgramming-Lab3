using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLab3.Logic
{
    public class SystemInfo
    {
        public void DisplayMemoryInfo()
        {
            Console.WriteLine("Counting in progress...");
            var info = new PerformanceCounter("Memory", "Available MBytes");
            Console.WriteLine($"Available system memory: {info.NextValue()}MB");
        }

        public void DisplayMachineName()
        {
            Console.WriteLine($"Machine name: {Environment.MachineName}");
        }

        public void DisplayUserName()
        {
            Console.WriteLine($"Current user: {Environment.UserName}");
        }

        public void DisplayDirectoryInfo()
        {
            Console.WriteLine($"Current system directory: {Environment.SystemDirectory}");
            Console.WriteLine($"Temporary directory: {Path.GetTempPath()}");
            Console.WriteLine($"Current working directory: {Environment.CurrentDirectory}");
        }
    }
}
