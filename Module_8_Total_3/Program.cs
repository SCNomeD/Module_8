using System;
using System.IO;

namespace Module_8_Total_3
{
    class Program
    {
        static void Main(string[] args)
        {
            const double time = 0.1;
            string Path;
            long Cleared = 0;
            while (true)
            {
                Console.Write("Введите полный путь до папки.\nВвод: ");
                Path = Console.ReadLine();
                if (Directory.Exists(Path)) break;
                else Console.WriteLine("Ошибка: Проверьте путь, папка не найдена!");
            }
            long Initial = MyTask.GetDirSize(Path);
            Console.WriteLine($"\nИсходный вес папки: {Initial} байт");

            var directory = new DirectoryInfo(Path);
            DirsDelete(directory, ref Cleared);
            Console.WriteLine($"Освобождено {Cleared} байт");

            Console.WriteLine($"Теперь папка весит {MyTask.GetDirSize(Path)} байт");

            static void DirsDelete(DirectoryInfo directory, ref long cleared)
            {
                FilesDelete(directory, ref cleared);
                foreach (DirectoryInfo dir in directory.GetDirectories())
                {
                    if (dir.GetFiles().Length > 0)
                        FilesDelete(dir, ref cleared);
                    if (dir.GetDirectories().Length > 0)
                        DirsDelete(dir, ref cleared);
                    if (dir.GetFiles().Length == 0 && dir.GetDirectories().Length == 0
                        && DateTime.Now - dir.LastAccessTime > TimeSpan.FromMinutes(time))
                    {
                        try
                        {
                            dir.Delete();
                        }
                        catch { }
                    }
                }
            }
            static void FilesDelete(DirectoryInfo directory, ref long cleared)
            {
                foreach (var file in directory.GetFiles())
                    if (DateTime.Now - file.LastAccessTime > TimeSpan.FromMinutes(time))
                    {
                        cleared += file.Length;
                        file.Delete();
                    }
            }
        }
    }
}
