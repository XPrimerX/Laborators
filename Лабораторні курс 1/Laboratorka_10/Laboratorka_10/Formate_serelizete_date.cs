using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Laboratorka_10
{
    public class Formate_serelizete_date
    {
        #pragma warning disable SYSLIB0011 // Тип или член устарел
              static  BinaryFormatter formatter = new BinaryFormatter();
        static XmlSerializer serializer = new XmlSerializer(typeof(Bus[]));

        public static void Formate_Byte_date(Bus[] bus)
        {
            Console.WriteLine("Напиши назву файлу");
            string name_file = Console.ReadLine();
            using (FileStream fs = new FileStream($"{name_file}.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, bus);
                Console.WriteLine($"Обєкт серіалізовано до файлу {name_file}");
            }
        }
        public static void Deserilezasia_byte_date()
        {
            Console.WriteLine("Напиши назву файлу");
            string name_file = Console.ReadLine();
            using (FileStream fs = new FileStream($"{name_file}.dat", FileMode.OpenOrCreate))
            {
                Bus[] deserilizeBus = (Bus[])formatter.Deserialize(fs);
                foreach (Bus buses in deserilizeBus)
                {
                    Console.WriteLine(buses.ToString());
                }
            }
        }

        #pragma warning restore SYSLIB0011 // Тип или член устарел

        public static void Serilezid_by_xml(Bus[] bus)
        {
        
            Console.WriteLine("Напиши назву файлу");
            string name_file = Console.ReadLine();
            using (FileStream fs = new FileStream($"{name_file}.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, bus);
                Console.WriteLine($"Обєкт серіалізовано до файлу {name_file}");
            }
        }
        public static void Deserilezid_by_xml()
        {
            Console.WriteLine("Напиши назву файлу");
            string name_file = Console.ReadLine();
            using (FileStream fs = new FileStream($"{name_file}.xml", FileMode.OpenOrCreate))
            {
                Bus[] deserilizeBus = (Bus[])serializer.Deserialize(fs);
                foreach (Bus buses in deserilizeBus)
                {
                    Console.WriteLine(buses.ToString());
                }
            }
        }
        public static async Task Serilezid_by_json(Bus[] bus)
        {
            Console.WriteLine("Напиши назву файлу");
            string name_file = Console.ReadLine();
            using (FileStream fs = new FileStream($"{name_file}.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, bus);
                Console.WriteLine($"Обєкт серіалізовано до файлу {name_file}");
            }
        }
        public static async Task Deserilezid_by_json()
        {
            Console.WriteLine("Напиши назву файлу");
            string name_file = Console.ReadLine();
            using (FileStream fs = new FileStream($"{name_file}.json", FileMode.OpenOrCreate))
            {
                Bus[] bus = await JsonSerializer.DeserializeAsync<Bus[]>(fs);
                foreach (Bus buses in bus)
                {
                    Console.WriteLine(buses.ToString());
                }
            }
        }
        public static void Print_for_criteria(Bus[] buses)
        {
            Console.WriteLine("Введіть пункт призначення:");
            string Punkt = Console.ReadLine();

            Console.WriteLine($"Автобуси, що прямують до {Punkt}:");
            foreach (var bus in buses)
            {
                if (bus.Punkt == Punkt && bus.pid.Length <= 7)
                {
                    Console.WriteLine($"Автобус номер{bus.nomer}, Водій: {bus.pid}");
                }
                else
                {
                    Console.WriteLine("None");
                }
            }
        }
    }
}
