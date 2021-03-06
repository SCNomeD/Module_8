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
                else Console.WriteLine("Ошибка: Проверьте путь, папка не найдена!");
            }
            DirectoryInfo directory = new DirectoryInfo(Path);

            DirDelete(directory);

            static void DirDelete(DirectoryInfo directory)
            {
                FilesDelete(directory);
                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    if (dir.GetFiles().Length > 0)
                        FilesDelete(dir);
                    if (dir.GetDirectories().Length > 0)
                        DirDelete(dir);
                    if (dir.GetFiles().Length == 0 && dir.GetDirectories().Length == 0
                        && DateTime.Now - dir.LastAccessTime > TimeSpan.FromMinutes(time))
                    {
                        try
                        {
                            dir.Delete();
                            Console.WriteLine($"Папка {dir.FullName} была удалена");
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
                        Console.WriteLine($"Файл {file.FullName} был удален");
                    }
            }
        }
    }
}
