using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_1.Task_2
{
    public class Job_2
    {
        public static List<string> find_file(string dirName)
        {
            
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Подкаталоги:");
                List<string> txtFiles = new List<string>(Directory.GetFiles(dirName, "*.txt"));
                Console.WriteLine("Знайдені текстові файли:");
                for (int i = 0; i < txtFiles.Count; i++)
                {
                    Console.WriteLine($"{i}. {Path.GetFileName(txtFiles[i])}");
                }

                return txtFiles;
            }
            else
            {
                Console.WriteLine($"Каталог {dirName} не існує!");
                return new List<string>();
            }


        }
        public static Dictionary<string, int> rachunok_word(string dirName)
        {
            string[] words;
            using (StreamReader sr = File.OpenText(dirName))
            {
                words = sr.ReadToEnd().Split(new char[] { ' ', '\t', '\n', '\r', ',', '.', '!', '?', ';', ':', '-', '(', ')', '"', '\'' }, StringSplitOptions.RemoveEmptyEntries);
            }
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                    wordCount[word]++;
                else
                    wordCount[word] = 1;
            }
            return wordCount;
        }
        public static void Satistic(Dictionary<string, int> wordCount)
        {
            Console.WriteLine("Статистика слів у файлі:");
            foreach (var ele in wordCount.OrderByDescending(p => p.Value))
            {
                Console.WriteLine($"{ele.Key}: {ele.Value}");

            }
            Console.Write("\nБажаєте зберегти статистику у файл? 1-так 2-ні");
            int otvet = int.Parse(Console.ReadLine()?? "2");
            if (otvet == 1)
            {
                using (StreamWriter sw = new StreamWriter("firstFile.txt"))
                {
                    foreach (var pair in wordCount.OrderByDescending(p => p.Value))
                    {
                        sw.WriteLine($"{pair.Key}: {pair.Value}");
                    }
                }
                Console.WriteLine($"Статистика збережена у файл firstFile.txt");
            }


        }
    }

}
