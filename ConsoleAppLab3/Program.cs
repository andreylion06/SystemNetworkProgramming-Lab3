using ConsoleAppLab3.Logic;

var diskInfo = new DiskInfo();
var systemInfo = new SystemInfo();

var items = new Dictionary<string, Action>
    {
        { "Display logic drivers", () => diskInfo.DisplayLogicalDrives() },
        { "Display disk types", () => diskInfo.DisplayDiskTypes() },
        { "Display file system info", () => { diskInfo.DisplayFileSystemInfo(); } },
        { "Display disk space", () => { diskInfo.DisplayDiskSpace(); } },
        { "Display memory info", () => { systemInfo.DisplayMemoryInfo(); } },
        { "Display machine name", () => { systemInfo.DisplayMachineName(); } },
        { "Display user name", () => { systemInfo.DisplayUserName(); } },
        { "Display directory info", () => { systemInfo.DisplayDirectoryInfo(); } },
        { "Start monitoring the folder with the path", () => {
            string pathToDirectory = @"C:\Users\User\Desktop\TestFolder";
            DirectoryWatcher watcher = new DirectoryWatcher(pathToDirectory);

            watcher.StartWatching();
            Console.WriteLine("Press 'q' to quit the sample.");
            while (Console.Read() != 'q');

            watcher.StopWatching();
        } },
        { "Exit 3", () => { Console.WriteLine("Exiting the program"); Environment.Exit(0); } }
    };

var menu = new Menu(items);

while (true)
{
    menu.DisplayOptions();
    string? option = menu.ChooseOption();
    menu.HandleInput(option);
    menu.WaitNextIteration();
}