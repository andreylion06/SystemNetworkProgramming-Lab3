using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ім'я файлу: DirectoryWatcher.cs
// Ремарка: DirectoryWatcher відслідковує зміни в обраному каталозі та записує ці зміни в лог-файл.
// Автор: Андрій Сахно

namespace ConsoleAppLab3.Logic
{
    public class DirectoryWatcher
    {
        // Для обраних каталогу на диску, Включити спостереження за змінами,
        // продемонструвати відслідковування більше однієї зміни.Зміни
        // записувати в лог файл.
        private FileSystemWatcher watcher;

        public DirectoryWatcher(string path)
        {
            watcher = new FileSystemWatcher(path);
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Changed += OnChildrenWereChanged;
            watcher.Created += OnChildrenWereChanged;
            watcher.Deleted += OnChildrenWereChanged;
            watcher.Renamed += OnChildrenWereRenamed;
        }

        public void StartWatching()
        {
            watcher.EnableRaisingEvents = true;
            Console.WriteLine("Started watching directory.");
        }

        public void StopWatching()
        {
            watcher.EnableRaisingEvents = false;
            Console.WriteLine("Stopped watching directory.");
        }

        private void OnChildrenWereChanged(object source, FileSystemEventArgs e)
        {
            string log = $"File: {e.FullPath} {e.ChangeType}";
            Console.WriteLine(log);
            File.AppendAllText("log.txt", log + Environment.NewLine);
        }

        private void OnChildrenWereRenamed(object source, RenamedEventArgs e)
        {
            string log = $"File: {e.OldFullPath} renamed to {e.FullPath}";
            Console.WriteLine(log);
            File.AppendAllText("log.txt", log + Environment.NewLine);
        }
    }
}

// Кінець файлу