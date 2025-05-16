using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laboratorka_9
{
    public class Work_for_text
    {
        public static string delete_wrong_word(string dirName_1, string dirName_2)
        {
            string text;
            string[] words;
            using (StreamReader sr = File.OpenText(dirName_1))
            {
                text = sr.ReadToEnd();

            }

            using (StreamReader sr = File.OpenText(dirName_2))
            {
                words = sr.ReadToEnd().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            }

            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;
                text = Regex.Replace(text, $@"\b{Regex.Escape(word)}\b", "", RegexOptions.IgnoreCase);
            }
            return text;
        }
        public static string Secret_word(string dirName_1, string dirName_2)
        {
            string text;
            string[] words;
            using (StreamReader sr = File.OpenText(dirName_1))
            {
                text = sr.ReadToEnd();

            }

            using (StreamReader sr = File.OpenText(dirName_2))
            {
                words = sr.ReadToEnd().Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            }
            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;
                text = Regex.Replace(text, $@"\b{Regex.Escape(word)}\b", new string('*', word.Length), RegexOptions.IgnoreCase);
            }
            return text;
        }
        public static void Read_file_and_find_something(string dirName)
        {
            using (StreamReader sr = File.OpenText(dirName))
            {
                string text = sr.ReadToEnd();

                int kol_sentence = text.Count(c => c == '.' || c == '!' || c == '?');
                int kol_upper = text.Count(char.IsUpper);
                int kol_lower = text.Count(char.IsLower);
                int kol_digit = text.Count(char.IsDigit);
                int kol_vowel = text.Count(c => "аеєиіїоуюяАЕЄИІЇОУЮЯ".Contains(c));
                int kol_consonant = text.Count(c => "бвгґджзйклмнпрстфхцчшщБВГҐДЖЗЙКЛМНПРСТФХЦЧШЩ".Contains(c));

                Console.WriteLine("\nСтатистика файлу:");
                Console.WriteLine($"Кількість речень: {kol_sentence}");
                Console.WriteLine($"Кількість великих літер: {kol_upper}");
                Console.WriteLine($"Кількість маленьких літер: {kol_lower}");
                Console.WriteLine($"Кількість голосних літер: {kol_vowel}");
                Console.WriteLine($"Кількість приголосних літер: {kol_consonant}");
                Console.WriteLine($"Кількість цифр: {kol_digit}");
            }
        }
    }
}
