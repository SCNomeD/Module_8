using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Module_8_4
{
    #region start
    //class BinaryExperiment
    //{
    //    const string SettingsFileName = "Settings.cfg";

    //    static void Main()
    //    {
    //        // Пишем
    //        WriteValues();
    //        // Считываем
    //        ReadValues();
    //    }

    //    static void WriteValues()
    //    {
    //        // Создаем объект BinaryWriter и указываем, куда будет направлен поток данных
    //        using (BinaryWriter writer = new BinaryWriter(File.Open(SettingsFileName, FileMode.Create)))
    //        {
    //            // записываем данные в разном формате
    //            writer.Write(20.666F);
    //            writer.Write(@"Тестовая строка");
    //            writer.Write(55);
    //            writer.Write(false);
    //        }
    //    }

    //    static void ReadValues()
    //    {
    //        float FloatValue;
    //        string StringValue;
    //        int IntValue;
    //        bool BooleanValue;

    //        if (File.Exists(SettingsFileName))
    //        {
    //            // Создаем объект BinaryReader и инициализируем его возвратом метода File.Open.
    //            using (BinaryReader reader = new BinaryReader(File.Open(SettingsFileName, FileMode.Open)))
    //            {
    //                // Применяем специализированные методы Read для считывания соответствующего типа данных.
    //                FloatValue = reader.ReadSingle();
    //                StringValue = reader.ReadString();
    //                IntValue = reader.ReadInt32();
    //                BooleanValue = reader.ReadBoolean();
    //            }

    //            Console.WriteLine("Из файла считано:");

    //            Console.WriteLine("Дробь: " + FloatValue);
    //            Console.WriteLine("Строка: " + StringValue);
    //            Console.WriteLine("Целое: " + IntValue);
    //            Console.WriteLine("Булево значение " + BooleanValue);
    //        }
    //    }
    //}
    #endregion
    #region 8.4.1 прочтение из папки с программой
    //class BinaryExperiment
    //{
    //    const string SettingsFileName = "BinaryFile.bin";

    //    static void Main()
    //    {
    //        // Считываем
    //        ReadValues();
    //    }

    //    static void ReadValues()
    //    {
    //        string StringValue;

    //        if (File.Exists(SettingsFileName))
    //        {
    //            // Создаем объект BinaryReader и инициализируем его возвратом метода File.Open.
    //            using (BinaryReader reader = new BinaryReader(File.Open(SettingsFileName, FileMode.Open)))
    //            {
    //                // Применяем специализированные методы Read для считывания соответствующего типа данных.
    //                StringValue = reader.ReadString();
    //            }

    //            Console.WriteLine("Из файла считано:");

    //            Console.WriteLine("Строка: " + StringValue);
    //        }
    //    }
    //}
    #endregion
    #region 8.4.1 корректный
    //class Program
    //{
    //    public static void Main()
    //    {
    //        // сохраняем путь к файлу (допустим, вы его скачали на рабочий стол)
    //        string filePath = @"C:\Users\vladi\OneDrive\Рабочий стол\BinaryFile.bin";

    //        // при запуске проверим, что файл существует
    //        if (File.Exists(filePath))
    //        {
    //            // строковая переменная, в которую будем считывать данные
    //            string stringValue;

    //            // считываем, после использования высвобождаем задействованный ресурс BinaryReader
    //            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
    //            {
    //                stringValue = reader.ReadString();
    //            }

    //            // Вывод
    //            Console.WriteLine("Из файла считано:");
    //            Console.WriteLine(stringValue);
    //        }
    //    }
    //}
    #endregion
    #region 8.4.2
    class Program
    {
        // сохраняем путь к файлу (допустим, вы его скачали на рабочий стол)
        const string filePath = @"C:\Users\vladi\OneDrive\Рабочий стол\BinaryFile.bin";
        public static void Main()
        {
            ReadValues();
        }
        public static void ReadValues()
        {
            // при запуске проверим, что файл существует
            if (File.Exists(filePath))
            {
                // строковая переменная, в которую будем считывать данные
                string stringValue;

                // считываем, после использования высвобождаем задействованный ресурс BinaryReader
                using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    stringValue = reader.ReadString();
                }

                // Вывод
                Console.WriteLine("Из файла считано:");
                Console.WriteLine(stringValue);
            }
        }
        public static void WriteValues()
        {
            // сохраняем путь к файлу (допустим, вы его скачали на рабочий стол)

            // при запуске проверим, что файл существует
            if (File.Exists(filePath))
            {
                // Создаем объект BinaryWriter и указываем, куда будет направлен поток данных
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    // записываем данные
                    writer.Write($"Файл изменен {DateTime.Now} на компьютере c ОС {Environment.OSVersion}");
                }
            }
        }
    }
    #endregion
    #region 8.4.2 (dop Сериализация)
    //// Описываем наш класс и помечаем его атрибутом для последующей сериализации   
    //[Serializable]
    //class Pet
    //{
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //    public Pet(string name, int age)
    //    {
    //        Name = name;
    //        Age = age;
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        // объект для сериализации
    //        var person = new Pet("Rex", 2);
    //        Console.WriteLine("Объект создан");

    //        BinaryFormatter formatter = new BinaryFormatter();
    //        // получаем поток, куда будем записывать сериализованный объект
    //        using (var fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
    //        {
    //            formatter.Serialize(fs, person);
    //            Console.WriteLine("Объект сериализован");
    //        }
    //        // десериализация
    //        using (var fs = new FileStream("myPets.dat", FileMode.OpenOrCreate))
    //        {
    //            var newPet = (Pet)formatter.Deserialize(fs);
    //            Console.WriteLine("Объект десериализован");
    //            Console.WriteLine($"Имя: {newPet.Name} --- Возраст: {newPet.Age}");
    //        }
    //        Console.ReadLine();
    //    }
    //}
    #endregion
    #region 8.4.3
    //// Описываем наш класс и помечаем его атрибутом для последующей сериализации   
    //[Serializable]
    //class Contact
    //{
    //    public string Name { get; set; }
    //    public long PhoneNumber { get; set; }
    //    public string Email { get; set; }
    //    public Contact(string name, long phoneNumber, string email)
    //    {
    //        Name = name;
    //        PhoneNumber = phoneNumber;
    //        Email = email;
    //    }
    //}

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        // объект для сериализации
    //        var contact = new Contact("Владимир", 89645045452, "vladiiimir1991@gmail.com");
    //        Console.WriteLine("Объект создан");

    //        BinaryFormatter formatter = new BinaryFormatter();
    //        // получаем поток, куда будем записывать сериализованный объект
    //        using (var fs = new FileStream("myContacts.dat", FileMode.OpenOrCreate))
    //        {
    //            formatter.Serialize(fs, contact);
    //            Console.WriteLine("Объект сериализован");
    //        }
    //        // десериализация
    //        using (var fs = new FileStream("myContacts.dat", FileMode.OpenOrCreate))
    //        {
    //            var newContact = (Contact)formatter.Deserialize(fs);
    //            Console.WriteLine("Объект десериализован");
    //            Console.WriteLine($"Имя: {newContact.Name} --- Тел. номер: {newContact.PhoneNumber} --- Email: {newContact.Email}");
    //        }
    //        Console.ReadLine();
    //    }
    //}
    #endregion
}