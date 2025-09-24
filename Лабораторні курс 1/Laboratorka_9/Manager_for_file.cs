using laboratorka_9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Laboratorka_9
{
    public class Manager_for_file
    {
        public static void find_file(string dirName)
        {
            //string dirName;
            //string names_disk;
            //Console.Write("Напишіть назву каталогу(C,D,E):");
            //names_disk = Console.ReadLine().ToUpper();
            //dirName = $"{names_disk}:\\";

            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(dirName);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(dirName);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }


        }
        public static void Create_file(string dirName,string text)
        {
            try
            {
              
                using (FileStream fs = File.Create(dirName))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(text);
                    fs.Write(info, 0, info.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        
        public static void Save_file(string text)
        {
            Console.Write("\nБажаєте зберегти результат у файл? 1-так 2-ні: ");
            if (Program.Checking() == 1)
            {
                Console.Write("Введіть шлях для збереження: ");
                string dirName_3 = Console.ReadLine();
                Create_file(dirName_3, text);
                Console.WriteLine("Збережено.");
            }
        }
        
    }
}
