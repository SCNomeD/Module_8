using System;
using System.IO;

namespace Module_8_Total_1
{

    class Program
    {
        static void Main(string[] args)
        {
            const double time = 30;
            string Path;

            while (true)
            {
                Console.Write("Введите полный путь до папки: ");
                Path = Console.ReadLine();
                if (Directory.Exists(Path)) break;
                else Console.WriteLine("Ошибка: данная папка не найдена. Повторите попытку.");
            }
            DirectoryInfo directory = new DirectoryInfo(Path);

            DirsDelete(directory);

            static void DirsDelete(DirectoryInfo directory)
            {
                FilesDelete(directory);
                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    if (dir.GetFiles().Length > 0)
                        FilesDelete(dir);
                    if (dir.GetDirectories().Length > 0)
                        DirsDelete(dir);
                    if (dir.GetFiles().Length == 0 && dir.GetDirectories().Length == 0
                        && DateTime.Now - dir.LastAccessTime > TimeSpan.FromMinutes(time))
                    {
                        try
                        {
                            dir.Delete();
                            Console.WriteLine($"Была удалена папка {dir.FullName}");
                        }
                        catch
                        {
                            Console.WriteLine($"Отказано в доступе к папке {dir.FullName}");
                        }
                    }
                }
            }
            static void FilesDelete(DirectoryInfo directory)
            {
                foreach (var file in directory.GetFiles())
                    if (DateTime.Now - file.LastAccessTime > TimeSpan.FromMinutes(time))
                    {
                        file.Delete();
                        Console.WriteLine($"Был удалён файл {file.FullName}");
                    }
            }
        }
    }
}
