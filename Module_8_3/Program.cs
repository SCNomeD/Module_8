using System;
using System.IO;

namespace Module_8_3
{
    class FileWriter
    {
        public static void Main()
        #region start
        //{
        //    string filePath = @"D:\Test\Test_8.3\Students.txt"; // Укажем путь 
        //    if (!File.Exists(filePath)) // Проверим, существует ли файл по данному пути
        //    {
        //        //   Если не существует - создаём и записываем в строку
        //        using (StreamWriter sw = File.CreateText(filePath))  // Конструкция Using (будет рассмотрена в последующих юнитах)
        //        {
        //            sw.WriteLine("Олег");
        //            sw.WriteLine("Дмитрий");
        //            sw.WriteLine("Иван");
        //        }
        //    }
        //    // Откроем файл и прочитаем его содержимое
        //    using (StreamReader sr = File.OpenText(filePath))
        //    {
        //        string str = "";
        //        while ((str = sr.ReadLine()) != null) // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
        //        {
        //            Console.WriteLine(str);
        //        }
        //    }
        //}
        #endregion
        #region 8.3.1
        //{
        //    string filePath = @"D:\vs\Module_8-master\Module_8_3\Program.cs"; // Укажем путь

        //    // Откроем файл и прочитаем его содержимое
        //    using (StreamReader sr = File.OpenText(filePath))
        //    {
        //        string str = "";
        //        while ((str = sr.ReadLine()) != null)
        //            Console.WriteLine(str);
        //    }
        //}
        #endregion
        #region 8.3.1(dop)
        //{
        //    string tempFile = Path.GetTempFileName(); // используем генерацию имени файла.
        //    var fileInfo = new FileInfo(tempFile); // Создаем объект класса FileInfo.

        //    //Создаем файл и записываем в него.
        //    using (StreamWriter sw = fileInfo.CreateText())
        //    {
        //        sw.WriteLine("Игорь");
        //        sw.WriteLine("Андрей");
        //        sw.WriteLine("Сергей");
        //    }

        //    //Открываем файл и читаем из него.
        //    using (StreamReader sr = fileInfo.OpenText())
        //    {
        //        string str = "";
        //        while ((str = sr.ReadLine()) != null)
        //        {
        //            Console.WriteLine(str);
        //        }
        //    }

        //    try
        //    {
        //        string tempFile2 = Path.GetTempFileName();
        //        var fileInfo2 = new FileInfo(tempFile2);

        //        // Убедимся, что файл назначения точно отсутствует
        //        fileInfo2.Delete();

        //        // Копируем информацию
        //        fileInfo.CopyTo(tempFile2);
        //        Console.WriteLine($"{tempFile} скопирован в файл {tempFile2}.");

        //        //Удаляем ранее созданный файл.
        //        fileInfo.Delete();
        //        Console.WriteLine($"{tempFile} удален.");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"Ошибка: {e}");
        //    }
        //}
        #endregion
        #region 8.3.2
        {
            string filePath = @"D:\vs\Module_8-master\Module_8_3\Program.cs"; // Укажем путь

            // Добавим в файл информацию о последнем запуске
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"// Время запуска: {DateTime.Now}");
            }

            // Откроем файл и прочитаем его содержимое
            using (StreamReader sr = File.OpenText(filePath))
            {
                string str = "";
                while ((str = sr.ReadLine()) != null)
                    Console.WriteLine(str);
            }
        }
        #endregion
    }
}
