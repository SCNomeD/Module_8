using System;
using System.Collections.Generic;

namespace Module_8_1
{
    public class Drive
    {
        enum DriveType
        {
            USB,
            HDD,
            CD
        }
        public Drive(string name, long totalSpace, long freeSpace)
        {
            Name = name;
            TotalSpace = totalSpace;
            FreeSpace = freeSpace;
        }
        public string Name { get; }
        public long TotalSpace { get; }
        public long FreeSpace { get; }
    }
    public class Folder
    {
        public List<string> Files { get; set; } = new List<string>();

        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();
        public void CreateFolder(string name)
        {
            Folders.Add(name, new Folder());
        }
    }
    public class SystemDrive : Drive
    {
        public SystemDrive() : base("C", 1024, 500)
        {

        }
    }
    //public class Folder
    //{
    //    public Folder(string name)
    //    {
    //        Name = name;
    //    }
    //    string Name { get; set; }
    //    List<string> Files { get; set; } = new List<string>();
    //    public void AddFile(string name)
    //    {
    //        if (!Files.Contains(name))
    //            Files.Add(name);
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello_World!");
        }
    }
}
