using System;

namespace Module_8_Total_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите полный путь до папки: ");
            var path = Console.ReadLine();
            if (path != null)
            Console.WriteLine(MyTask.GetDirSize(path));
        }
    }
}
