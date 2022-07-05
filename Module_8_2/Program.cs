using System;
using System.IO;

namespace Module_8_2
{
    class Program
    {
        static void Main(string[] args)
        #region Раздел диски
        //{
        //    //получим системные диски
        //    DriveInfo[] drives = DriveInfo.GetDrives();

        //    // Пробежимся по дискам и выведем их свойства
        //    foreach (DriveInfo drive in drives)
        //    {
        //        Console.WriteLine($"Название: {drive.Name}");
        //        Console.WriteLine($"Тип: {drive.DriveType}");
        //        if (drive.IsReady)
        //        {
        //            Console.WriteLine($"Объем: {drive.TotalSize}");
        //            Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
        //            Console.WriteLine($"Метка: {drive.VolumeLabel}");
        //        }
        //    }
        //}
        #endregion
        #region Раздел каталоги (папки)
        //{
        //    GetCatalogs(); // Вызов метода получения директорий
        //}
        //static void GetCatalogs()
        //{
        //    string dirName = @"D:\Test"; // Прописываем путь к корневой директории
        //    if (Directory.Exists(dirName)) // Проверим, что директория существует
        //    {
        //        Console.WriteLine("Папки:");
        //        string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

        //        foreach (string d in dirs) // Выведем их все
        //            Console.WriteLine(d);

        //        Console.WriteLine();
        //        Console.WriteLine("Файлы:");
        //        string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

        //        foreach (string s in files)   // Выведем их все
        //            Console.WriteLine(s);
        //    }
        //}
        #endregion
        #region 8.2.1
        //{
        //    try
        //    {
        //        DirectoryInfo dirInfo = new DirectoryInfo(@"D:\Test");
        //        if (dirInfo.Exists)
        //        {
        //            Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}
        #endregion
        #region 8.2.1(dop)
        //{
        //    // Создание новой дирректории в каталоге
        //    DirectoryInfo dirInfo = new DirectoryInfo(@"D:\Test");
        //    if (!dirInfo.Exists)
        //        dirInfo.Create();

        //    dirInfo.CreateSubdirectory("NewFolder");
        //}
        #endregion
        #region 8.2.2
        //{
        //    // создание новой дирректории
        //    try
        //    {
        //        DirectoryInfo dirInfo = new DirectoryInfo(@"D:\Test");
        //        if (dirInfo.Exists)
        //        {
        //            Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
        //        }

        //        DirectoryInfo newDirectory = new DirectoryInfo(@"D:\Test\newTest");
        //        if (!newDirectory.Exists)
        //            newDirectory.Create();

        //        Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    // удаление существующей дирректории
        //    try
        //    {
        //        DirectoryInfo dirInfo = new DirectoryInfo(@"D:\Test\Test_for_Delete");
        //        dirInfo.Delete(true); // Удаление со всем содержимым
        //        Console.WriteLine("Каталог удален");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
        #endregion
        #region 8.2.3
        //{
        //    // создание новой дирректории
        //    try
        //    {
        //        DirectoryInfo dirInfo = new DirectoryInfo(@"D:\Test");
        //        if (dirInfo.Exists)
        //        {
        //            Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
        //        }

        //        DirectoryInfo newDirectory = new DirectoryInfo(@"D:\Test\newTest");
        //        if (!newDirectory.Exists)
        //            newDirectory.Create();

        //        Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    // удаление созданной ранее дирректории
        //    try
        //    {
        //        DirectoryInfo dirInfo = new DirectoryInfo(@"D:\Test\newTest");
        //        dirInfo.Delete(true); // Удаление со всем содержимым
        //        Console.WriteLine("Каталог удален");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}
        #endregion
        #region 8.2.3(dop)
        //// перемещение в новую дирректорию
        //{
        //    DirectoryInfo dirInfo = new DirectoryInfo(@"D:\Test\Test_for_Move_1");
        //    string newPath = @"D:\Test\Test_for_Move_2";

        //    if (dirInfo.Exists && !Directory.Exists(newPath))
        //        dirInfo.MoveTo(newPath);
        //}
        #endregion
        #region 8.2.4
        // перемещение в корзину
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\vladi\OneDrive\Рабочий стол\TestFolder");
                string newPath = @"C:\$Recycle.Bin\TestFolder"; // OneDrive создал рабочий стол синхронизирующийся, хз как тут работает корзина в Wind-е
                dirInfo.MoveTo(newPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion
    }
}
