using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Module_8_Total_4
{
    class Program
    {
        public static void Main(string[] args)
        {
            const string Path = @"C:\Users\vladi\Downloads\Students.dat";
            BinaryFormatter formatter = new BinaryFormatter();
            Student[] students = null;
            using (var fs = new FileStream(Path, FileMode.Open))
            {
                try
                {
                    students = (Student[])formatter.Deserialize(fs);
                    foreach (var student in students)
                        Console.WriteLine($"{student.Name}   {student.Group}   {student.DateOfBirth}");
                }
                catch { }
            }
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\Students\";
            Directory.CreateDirectory(directory);
            Student.AddFiles(students, directory);
        }
    }
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
        public static void AddFiles(Student[] students, string dir)
        {
            foreach (var student in students)
            {
                var file = new FileInfo(dir + student.Group + ".txt");
                using (StreamWriter sw = file.AppendText())
                {
                    sw.WriteLine($"{student.Name}, {student.DateOfBirth.Day}.{student.DateOfBirth.Month}.{student.DateOfBirth.Year}");
                }
            }
        }
    }
}