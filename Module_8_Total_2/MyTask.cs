using System;
using System.IO;

public static class MyTask
{
    public static long GetDirSize(string dirURL)
    {
        DirectoryInfo directory;

        try
        {
            directory = new DirectoryInfo(dirURL);
        }
        catch
        {
            Console.WriteLine("Некорректная URL дирректории!");
            return 0;
        }

        long size = 0;

        try
        {
            foreach (var file in directory.GetFiles())
                size += file.Length;
        }
        catch { }

        try
        {
            foreach (DirectoryInfo dir in directory.GetDirectories())
                size += GetDirSize(dir.FullName);
        }
        catch { }

        return size;
    }
}