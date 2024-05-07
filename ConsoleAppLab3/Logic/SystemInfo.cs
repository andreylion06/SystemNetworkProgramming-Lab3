using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ім'я файлу: SystemInfo.cs
// Ремарка: SystemInfo надає інформацію про систему, включаючи системну пам'ять,
//          назву комп'ютера, ім'я користувача та інформацію про каталоги.
// Автор: Андрій Сахно

namespace ConsoleAppLab3.Logic
{
    public class SystemInfo
    {
        // Отримати інформацію про системну пам'ять.
        public void DisplayMemoryInfo()
        {
            Console.WriteLine("Counting in progress...");
            var info = new PerformanceCounter("Memory", "Available MBytes");
            Console.WriteLine($"Available system memory: {info.NextValue()}MB");
        }

        // Отримати інформацію про Назву комп'ютера
        public void DisplayMachineName()
        {
            Console.WriteLine($"Machine name: {Environment.MachineName}");
        }

        // Отримати Назву поточного користувача
        public void DisplayUserName()
        {
            Console.WriteLine($"Current user: {Environment.UserName}");
        }

        // Отримати інформацію про поточний системний каталог, Тимчасовий каталог, поточний робочий каталог.
        public void DisplayDirectoryInfo()
        {
            Console.WriteLine($"Current system directory: {Environment.SystemDirectory}");
            Console.WriteLine($"Temporary directory: {Path.GetTempPath()}");
            Console.WriteLine($"Current working directory: {Environment.CurrentDirectory}");
        }
    }
}

// Кінець файлу